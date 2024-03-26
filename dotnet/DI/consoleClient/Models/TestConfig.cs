using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleClient.Interfaces;

namespace consoleClient.Models;

public class TestConfig : IConfig
{
  public string GetValue(string name)
  {
    return $"{name} config";
  }
}
