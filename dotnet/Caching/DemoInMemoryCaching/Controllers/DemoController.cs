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

  public DemoController(IMemoryCache memoryCache)
  {
    _memoryCache = memoryCache;
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
}
