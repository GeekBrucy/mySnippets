using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigServices.Interfaces;

namespace ConfigServices.Utils;

public class LayeredConfigReader : IConfigReader
{
  /*
  Injecting multiple IConfigService, then in the GetValue, the later config will overwrite the previous one
  */
  private readonly IEnumerable<IConfigService> _services;
  public LayeredConfigReader(IEnumerable<IConfigService> services)
  {
    _services = services;
  }
  public string GetValue(string name)
  {
    string value = null;
    foreach (var service in _services)
    {
      string newValue = service.GetValue(name);

      if (newValue != null)
      {
        value = newValue;
      }
    }

    return value;
  }
}
