using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFConfigs.Interfaces;

public interface IDemo : IDisposable
{
  void Run();
  Task RunAsync();
}
