using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigServices.Interfaces;

namespace ConfigServices.Services;

public class EnvVarConfigService : IConfigService
{
  public string GetValue(string name)
  {
    return Environment.GetEnvironmentVariable(name);
  }
}
