using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionFilter.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoController : ControllerBase
{
  [HttpGet]
  public string UnhandledException()
  {
    string s = System.IO.File.ReadAllText("./test.txt");
    return s;
  }
}
