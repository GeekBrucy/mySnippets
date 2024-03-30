using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigServices.Interfaces;

public interface IConfigReader
{
  public string GetValue(string name);
}
