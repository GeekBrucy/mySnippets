using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibModule1.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainProject.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TestController : ControllerBase
{
  private readonly Service1 _module1Service1;

  public TestController(Service1 module1Service1)
  {
    _module1Service1 = module1Service1;
  }
}
