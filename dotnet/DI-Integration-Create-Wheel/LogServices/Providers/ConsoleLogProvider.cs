using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogServices.Interfaces;

namespace LogServices.Providers;

public class ConsoleLogProvider : ILogProvider
{
  public void LogError(string msg)
  {
    Console.WriteLine($"Error: {msg}");
  }

  public void LogInfo(string msg)
  {
    Console.WriteLine($"Info: {msg}");
  }
}
