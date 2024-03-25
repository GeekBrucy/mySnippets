using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consoleClient.Interfaces;

public interface ITestService
{
  public string Name { get; set; }
  public void SayHi();
}
