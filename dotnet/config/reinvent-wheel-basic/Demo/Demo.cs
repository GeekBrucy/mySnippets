using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using reinvent_wheel_basic.Models.Settings;

namespace reinvent_wheel_basic.Demo;

public class Demo
{
  private readonly IOptionsSnapshot<WebConfig> _webConfig;
  public Demo(IOptionsSnapshot<WebConfig> webConfig)
  {
    _webConfig = webConfig;
  }

  public void Run()
  {
    var config = _webConfig.Value;
    if (config == null)
    {
      Console.WriteLine("no val");
    }
    Console.WriteLine(config.Conn1.ConnectionString);
    Console.WriteLine(config.Conn1.ProviderName);
    Console.WriteLine(config.Config.Name);
    Console.WriteLine(config.Config.Age);
    Console.WriteLine(config.Config.Proxy.Address);
    Console.WriteLine(config.Config.Proxy.Port);
  }
}
