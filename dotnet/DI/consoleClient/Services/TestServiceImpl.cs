using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleClient.Interfaces;

namespace consoleClient.Services;

public class TestServiceImpl : ITestService
{
  public string Name { get; set; }

  public void SayHi()
  {
    Console.WriteLine($"Hi, I am {Name}");
  }
}
