using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilterUseCase_RequestThrottle.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoController : ControllerBase
{
  [HttpGet]
  public void Test()
  {
    Console.WriteLine("Running");
  }
}
