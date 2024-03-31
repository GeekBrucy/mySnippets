using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reinvent_wheel_basic.Models.Settings;

public class Proxy
{
  public string Address { get; set; }
  public int Port { get; set; }
  public int[] Ids { get; set; }
}