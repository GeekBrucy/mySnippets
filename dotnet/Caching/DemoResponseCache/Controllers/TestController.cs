using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoResponseCache.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
  [HttpGet]
  public DateTime Now()
  {
    return DateTime.Now;
  }
}
