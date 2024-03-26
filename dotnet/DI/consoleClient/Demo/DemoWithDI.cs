using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace consoleClient.Demo;

public class DemoWithDI
{
  public static void RunWithDI()
  {
    ServiceCollection services = new ServiceCollection();

    services.AddTransient<TestServiceImpl>();

    using ServiceProvider serviceProvider = services.BuildServiceProvider();

    var testService = serviceProvider.GetService<TestServiceImpl>();

    testService.Name = "From DI";
    testService.SayHi();
  }
}
