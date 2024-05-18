using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _01_Basic.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class Demo1Controller : ControllerBase
{
  private readonly ILogger _logger;
  public Demo1Controller(ILogger<Demo1Controller> logger)
  {
    _logger = logger;
  }
  [HttpGet]
  public ActionResult TestDemo1()
  {
    _logger.LogInformation("Test Demo1");
    return Ok();
  }
}
