using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using DemoResponseCache.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DemoInMemoryCaching.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoController : ControllerBase
{
  private readonly IMemoryCache _memoryCache;
  private readonly ILogger<DemoController> _logger;

  public DemoController(IMemoryCache memoryCache, ILogger<DemoController> logger)
  {
    _memoryCache = memoryCache;
    _logger = logger;
  }

  [HttpGet]
  public ActionResult<Book?> GetBookById(long id)
  {
    Book? result = FakeDbContext.GetById(id);

    if (result == null)
    {
      return NotFound($"Cannot find book with id {id}");
    }

    return result;
  }

  [HttpGet]
  public async Task<ActionResult<Book?>> GetBookByIdWithCacheAsync(long id)
  {
    /*
    GetOrCreateAsync
    1. Get data from Cache
    2. Fetch data from data source and return to caller
    */
    Console.WriteLine($"Start GetOrCreateAsync, id = {id}");
    Book? b = await _memoryCache.GetOrCreateAsync("Book " + id, async (e) =>
    {
      Console.WriteLine($"Cache not found, check data source for id = {id}");
      return await FakeDbContext.GetByIdAsync(id);
    });
    Console.WriteLine($"End GetOrCreateAsync result = {b}");
    if (b == null)
    {
      return NotFound($"Cannot find book with id {id}");
    }

    return b;
  }

  [HttpGet]
  public ActionResult<Book?> BadKeySelection(long id)
  {
    // it will cause problem if the key is not unique
    Console.WriteLine($"Start GetOrCreateAsync, id = {id}");
    Book? b = _memoryCache.GetOrCreate("Bad Key", (e) =>
    {
      Console.WriteLine($"Cache not found, check data source for id = {id}");
      return FakeDbContext.GetById(id);
    });
    Console.WriteLine($"End GetOrCreateAsync result = {b}");
    if (b == null)
    {
      return NotFound($"Cannot find book with id {id}");
    }
    return b;
  }
}
