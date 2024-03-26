using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consoleClient.Interfaces;

public interface IConfig
{
  public string GetValue(string name);
}
