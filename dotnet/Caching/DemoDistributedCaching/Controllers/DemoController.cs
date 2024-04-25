using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DemoDistributedCaching.Data;
using DemoDistributedCaching.Interfaces;
using DemoDistributedCaching.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace DemoDistributedCaching.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoController : ControllerBase
{
  private readonly IDistributedCache _distributedCache;
  private readonly IDistributedCacheHelper _distributedCacheHelper;

  public DemoController(IDistributedCache distributedCache)
  {
    _distributedCache = distributedCache;
  }

  [HttpGet]
  public async Task<ActionResult<Book?>> DistributedCache(long id)
  {
    string key = $"Book {id}";
    Book? book = null;
    string? s = await _distributedCache.GetStringAsync(key);
    if (s == null)
    {
      book = await FakeDbContext.GetByIdAsync(id);
      await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(book));
    }
    else
    {
      Console.WriteLine("Cache hit");
      book = JsonSerializer.Deserialize<Book?>(s);
    }

    if (book == null)
    {
      return NotFound($"No book with {id}");
    }

    return book;
  }

  [HttpGet]
  public async Task<ActionResult<Book?>> DistributedCacheHelper(long id)
  {
    string key = $"Book {id}";
    Book? book = await _distributedCacheHelper.GetOrCreateAsync(key, async (e) =>
    {
      // e.SlidingExpiration = TimeSpan.FromSeconds(20);
      return await FakeDbContext.GetByIdAsync(id);
    });

    if (book == null)
    {
      return NotFound($"No book with {id}");
    }

    return book;
  }
}
