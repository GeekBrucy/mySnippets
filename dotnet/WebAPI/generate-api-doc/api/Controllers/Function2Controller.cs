using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
[ApiExplorerSettings(GroupName = "external")]
public class Function2Controller : ControllerBase
{
  [HttpGet]
  public IActionResult Get(int param1, string param2)
  {
    return Ok();
  }

  [HttpPost]
  public IActionResult Post(int param1, string param2, [FromBody] Shot function1DTO)
  {
    return Ok();
  }
}
