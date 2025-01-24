using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("internal/[controller]")]
[ApiExplorerSettings(GroupName = "internal")]
public class InternalFunction2Controller : ControllerBase
{
  [HttpGet]
  public IActionResult Get(int param1, string param2)
  {
    return Ok();
  }
}
