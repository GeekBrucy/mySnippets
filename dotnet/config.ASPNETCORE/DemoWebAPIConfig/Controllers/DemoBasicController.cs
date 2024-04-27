using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using DemoWebAPIConfig.Data;
using DemoWebAPIConfig.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DemoWebAPIConfig.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoBasicController : ControllerBase
{
  private readonly IWebHostEnvironment _webEnv;
  private readonly Smtp _smtp;
  public DemoBasicController(IWebHostEnvironment webEnv, IOptionsSnapshot<Smtp> smtpOpt)
  {
    _webEnv = webEnv;
    _smtp = smtpOpt.Value;
  }
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

  [HttpGet]
  public IDictionary<string, string> GetAppEnvVar()
  {
    IDictionary<string, string> envVars = new Dictionary<string, string>
    {
        { nameof(_webEnv.ApplicationName), _webEnv.ApplicationName },
        { nameof(_webEnv.EnvironmentName), _webEnv.EnvironmentName },
        { nameof(_webEnv.ContentRootPath), _webEnv.ContentRootPath },
        { nameof(_webEnv.WebRootPath), _webEnv.WebRootPath }
    };

    return envVars;
  }

  [HttpGet]
  public Smtp GetAppSettingsFromDb()
  {
    if (_smtp == null)
    {
      Console.WriteLine("no config");
    }
    else
    {
      Console.WriteLine(_smtp);
    }
    return _smtp;
  }
}
