using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
/// <summary>
/// By default, webapi is using query string to pass parameter
/// </summary>
public class DemoParamController : ControllerBase
{
  [HttpGet("{i1}/{i2}")]
  /// <summary>
  /// [HttpGet("{i1}/{i2}")] force to pass param in the URL
  /// </summary>
  /// <param name="i1"></param>
  /// <param name="i2"></param>
  /// <returns></returns>
  public int URLParam(int i1, int i2)
  {
    return i1 * i2;
  }

  [HttpGet("{i1}/{i2}")]
  /// <summary>
  /// NOT Recommended
  /// </summary>
  /// <param name="firstNum"></param>
  /// <param name="secondNum"></param>
  /// <returns></returns>
  public int URLParamInconsistentParamName([FromRoute(Name = "i1")] int firstNum, [FromRoute(Name = "i2")] int secondNum)
  {
    return firstNum * secondNum;
  }

  [HttpPost]
  public int QueryStringExplicit([FromQuery(Name = "iii")] int i, [FromQuery(Name = "jjj")] int j)
  {
    return i + j;
  }
}
