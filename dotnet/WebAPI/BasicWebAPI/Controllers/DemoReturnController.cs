using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoReturnController : ControllerBase
{
  [HttpGet]
  public IActionResult GetNumber(int id)
  {
    switch (id)
    {
      case 1:
        return Ok(11);
      case 2:
        return Ok(22);
      default:
        return NotFound("wrong id");
    }
  }

  [HttpGet]
  /// <summary>
  /// IActionResult cannot use generic type, hence Swagger cannot display return type
  /// Use ActionResult instead 
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public ActionResult<int> GetNumberWithActionResult(int id)
  {
    switch (id)
    {
      case 1:
        return 11;
      case 2:
        return 22;
      default:
        return NotFound("wrong id");
    }
  }
}
