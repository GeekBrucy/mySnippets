using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleClient.Interfaces;
using consoleClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace consoleClient.Demo;

public class DemoWithDI_Interface_Oriented
{

  private readonly ServiceCollection _services;
  public DemoWithDI_Interface_Oriented()
  {
    _services = new ServiceCollection();
    _services.AddScoped<ITestService, TestServiceImpl>();
    _services.AddScoped<ITestService, TestServiceImpl2>();
    // another way to Add
    // _services.AddScoped(typeof(ITestService, typeof(TestServiceImpl)));
    // _services.AddScoped(typeof(ITestService, new TestServiceImpl()));
  }

  public void Run()
  {
    using ServiceProvider sp = _services.BuildServiceProvider();

    ITestService ts1 = sp.GetService<ITestService>();
    ts1.Name = "interface";
    ts1.SayHi();
    Console.WriteLine(ts1.GetType());
  }

  public void RunWithMultipleServices()
  {
    using ServiceProvider sp = _services.BuildServiceProvider();

    IEnumerable<ITestService> ts1 = sp.GetServices<ITestService>();
    foreach (var item in ts1)
    {
      Console.WriteLine(item.GetType());
    }
  }
}
