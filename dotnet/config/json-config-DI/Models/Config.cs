using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace json_config_DI.Models;

public class Config
{
  public string Name { get; set; }
  public int Age { get; set; }
  public Proxy Proxy { get; set; }
}