using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reinvent_wheel_basic.Models.Settings;

public class WebConfig
{
  public ConnectionStr Connstr1 { get; set; }
  public ConnectionStr Conn1 { get; set; }
  public ConnectionStr Conn2 { get; set; }

  public Config Config { get; set; }
}
