using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "external")]
public class Function1Controller : ControllerBase
{
  private readonly TestService _ts;
  public Function1Controller(TestService ts)
  {
    _ts = ts;
  }
  [HttpGet]
  public IActionResult Get(int param1, string param2)
  {
    return Ok(_ts.Test());
  }
  [HttpPost]
  public IActionResult Post(int param1, string param2, [FromBody] Function1DTO function1DTO)
  {
    return Ok();
  }
}
