using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using json_config_DI.Models;
using Microsoft.Extensions.Options;

namespace json_config_DI.Controllers;

public class Test2Controller
{
  private readonly IOptionsSnapshot<Proxy> _optProxy;

  public Test2Controller(IOptionsSnapshot<Proxy> optProxy)
  {
    _optProxy = optProxy;
  }

  public void Test()
  {
    Console.WriteLine(_optProxy.Value.Address);
    Console.WriteLine(_optProxy.Value.Port);
  }
}
