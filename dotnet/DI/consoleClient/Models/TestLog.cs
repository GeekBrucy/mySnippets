using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleClient.Interfaces;

namespace consoleClient.Models;

public class TestLog : ILog
{
  public void Log(string msg)
  {
    Console.WriteLine($"Log: {msg}");
  }
}
