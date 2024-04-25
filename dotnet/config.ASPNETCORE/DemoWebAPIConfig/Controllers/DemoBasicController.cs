using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPIConfig.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoBasicController : ControllerBase
{
  [HttpGet]
  public IDictionary<string, string> GetSystemEnvVar()
  {
    IDictionary<string, string> envVar = new Dictionary<string, string>();
    foreach (DictionaryEntry item in Environment.GetEnvironmentVariables())
    {
      envVar.Add(item.Key.ToString(), item.Value.ToString());
    }
    return envVar;
  }
  [HttpGet]
  public string GetEnvVar()
  {
    var val = Environment.GetEnvironmentVariable("TEST");
    return val;
  }
}
