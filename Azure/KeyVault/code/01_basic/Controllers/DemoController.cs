using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _01_basic.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoController : ControllerBase
{
  private readonly IConfiguration _config;
  public DemoController(IConfiguration config)
  {
    _config = config;
  }

  [HttpGet]
  public IActionResult GetConfig(string key)
  {
    if (string.IsNullOrEmpty(_config[key]))
    {
      return Ok($"{key} is empty");
    }
    return Ok(_config[key]);
  }
}
