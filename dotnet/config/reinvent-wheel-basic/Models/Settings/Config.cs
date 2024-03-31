using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reinvent_wheel_basic.Models.Settings;

public class Config
{
  public string Name { get; set; }
  public int Age { get; set; }
  public Proxy Proxy { get; set; }
}