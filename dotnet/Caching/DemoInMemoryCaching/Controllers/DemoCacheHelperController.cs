using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using DemoInMemoryCaching.Interfaces;
using DemoResponseCache.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoInMemoryCaching.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoCacheHelperController : ControllerBase
{
  private readonly IMemoryCacheHelper _memoryCacheHelper;

  public DemoCacheHelperController(IMemoryCacheHelper memoryCacheHelper)
  {
    _memoryCacheHelper = memoryCacheHelper;
  }

  [HttpGet]
  public IActionResult IEnumerablePitfall()
  {
    Console.WriteLine("Start");
    var items = IEnumerablePitfallExample(); // nothing happen at this stage. The console writeline will not run
    // to make it effective immediately, `IEnumerablePitfallExample().ToArray()`
    Console.WriteLine("End");
    foreach (var item in items)
    {
      Console.WriteLine(item);
    }
    return Ok();
  }

  private IEnumerable<int> IEnumerablePitfallExample()
  {
    yield return 1;
    yield return 2;
    yield return 3;
    Console.WriteLine("test");
    yield return 4;
    yield return 5;
  }

  public async Task<ActionResult<Book?>> CacheHelper(long id)
  {
    Book? b = await _memoryCacheHelper.GetOrCreateAsync("Book " + id, async (e) =>
    {
      return await FakeDbContext.GetByIdAsync(id);
    }, 10);
    if (b == null)
    {
      return NotFound($"no book with id {id}");
    }
    return b;
  }
}
