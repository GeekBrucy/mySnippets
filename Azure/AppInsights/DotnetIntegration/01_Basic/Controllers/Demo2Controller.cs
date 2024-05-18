using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _01_Basic.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class Demo2Controller : ControllerBase
{
  [HttpGet]
  public ActionResult TestDemo2()
  {
    return Ok();
  }
}
