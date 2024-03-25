using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleClient.Interfaces;

namespace consoleClient.Services;

public class TestServiceImpl2 : ITestService
{
  public string Name { get; set; }

  public void SayHi()
  {
    Console.WriteLine($"你好, 我是{Name}");
  }
}
