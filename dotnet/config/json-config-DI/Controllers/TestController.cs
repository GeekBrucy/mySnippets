using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using json_config_DI.Models;
using Microsoft.Extensions.Options;

namespace json_config_DI.Controllers;

public class TestController
{
  private readonly IOptionsSnapshot<Config> _optConfig;

  public TestController(IOptionsSnapshot<Config> optConfig)
  {
    _optConfig = optConfig;
  }

  public void Test()
  {
    Console.WriteLine(_optConfig.Value.Age);
    Console.WriteLine("**************************");
    Console.WriteLine(_optConfig.Value.Name);

  }
}
