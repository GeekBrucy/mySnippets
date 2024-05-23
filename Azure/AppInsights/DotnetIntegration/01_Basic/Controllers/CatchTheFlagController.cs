using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Basic.Data;
using _01_Basic.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_Basic.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CatchTheFlagController : ControllerBase
{
  private readonly MyDbContext _myDbContext;
  public CatchTheFlagController(MyDbContext myDbContext)
  {
    _myDbContext = myDbContext;
  }
  [HttpPost]
  public async Task<ActionResult<Flag>> AddFlag(string value)
  {
    var flag = new Flag
    {
      Value = value
    };

    _myDbContext.Flags.Add(flag);

    await _myDbContext.SaveChangesAsync();

    return new OkObjectResult(flag);
  }

  [HttpGet]
  public async Task<ActionResult<Flag>> CatchFlag(int? id)
  {
    id = id ?? 1;

    var flag = await _myDbContext.Flags.FindAsync(id);

    return new OkObjectResult(flag);
  }
}
