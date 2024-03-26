using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleClient.Interfaces;
using consoleClient.Models;
using consoleClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace consoleClient.Demo;

public class DemoDIInfectious
{
  public static void Run()
  {
    ServiceCollection services = new ServiceCollection();
    services.AddScoped<TestController>();
    services.AddScoped<ILog, TestLog>();
    services.AddScoped<IConfig, TestConfig>();
    services.AddScoped<IStorage, TestStorageImpl>();

    using var sp = services.BuildServiceProvider();
    var c = sp.GetRequiredService<TestController>();
    c.Run();
  }
}
