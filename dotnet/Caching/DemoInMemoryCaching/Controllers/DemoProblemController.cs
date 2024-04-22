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
public class DemoProblemController : ControllerBase
{
  private readonly IMemoryCache _memoryCache;
  private readonly ILogger<DemoProblemController> _logger;

  public DemoProblemController(IMemoryCache memoryCache, ILogger<DemoProblemController> logger)
  {
    _memoryCache = memoryCache;
    _logger = logger;
  }

  [HttpGet]
  public async Task<ActionResult<Book?>> CachePenetration(long id)
  {
    // GetOrCreateAsync will treat null as cahce hit
    Console.WriteLine($"Start GetOrCreateAsync, id = {id}");
    Book? b = await _memoryCache.GetOrCreateAsync("Book " + id, async (e) =>
    {
      Console.WriteLine($"Cache not found, check data source for id = {id}");
      var book = await FakeDbContext.GetByIdAsync(id);
      Console.WriteLine($"data from source: {book}");
      return book;
    });
    Console.WriteLine($"End GetOrCreateAsync result = {b}");
    if (b == null)
    {
      return NotFound($"Cannot find book with id {id}");
    }

    return b;
  }
}
