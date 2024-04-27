using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIConfig.Models.Settings;

public class Smtp
{
  public string Server { get; set; }
  public string UserName { get; set; }
  public string Password { get; set; }

  public override string ToString()
  {
    return $"Server={Server}, UserName={UserName}, Password={Password}";
  }
}
