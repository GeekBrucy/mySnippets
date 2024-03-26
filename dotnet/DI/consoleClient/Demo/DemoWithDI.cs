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

  public static void RunWithTransient()
  {
    ServiceCollection services = new ServiceCollection();

    services.AddTransient<TestServiceImpl>();

    using ServiceProvider serviceProvider = services.BuildServiceProvider();

    var obj1 = serviceProvider.GetService<TestServiceImpl>();
    obj1.Name = "OBJ 1";
    var obj2 = serviceProvider.GetService<TestServiceImpl>();
    obj2.Name = "OBJ 2";

    // the obj1 Name is not changed
    obj1.SayHi();

    var isEqual = object.ReferenceEquals(obj1, obj2);
    // will return false, because TestServiceImpl is instantiated every time
    Console.WriteLine(isEqual ? "Same" : "Not Same");
  }

  public static void RunWithSingleton()
  {
    ServiceCollection services = new ServiceCollection();

    services.AddSingleton<TestServiceImpl>();

    using ServiceProvider serviceProvider = services.BuildServiceProvider();

    var obj1 = serviceProvider.GetService<TestServiceImpl>();
    obj1.Name = "OBJ 1";
    var obj2 = serviceProvider.GetService<TestServiceImpl>();
    obj2.Name = "OBJ 2";

    // the obj1 Name IS changed to OBJ 2, because of singleton
    obj1.SayHi();

    var isEqual = object.ReferenceEquals(obj1, obj2);
    // will return true, because TestServiceImpl is only instantiated once
    Console.WriteLine(isEqual ? "Same" : "Not Same");
  }

  /// <summary>
  /// Normally, the scope is defined within the Framework or by the developer
  /// </summary>
  public static void RunWithScoped()
  {
    ServiceCollection services = new ServiceCollection();

    services.AddScoped<TestServiceImpl>();

    using ServiceProvider serviceProvider = services.BuildServiceProvider();

    // create scope
    using IServiceScope scope1 = serviceProvider.CreateScope();
    // the service provider here is only for scope1
    var obj1 = scope1.ServiceProvider.GetService<TestServiceImpl>();
    obj1.Name = "OBJ 1";
    var obj2 = scope1.ServiceProvider.GetService<TestServiceImpl>();
    obj2.Name = "OBJ 2";

    // the obj1 Name IS changed to OBJ 2, because of scoped
    obj1.SayHi();

    var isEqual = object.ReferenceEquals(obj1, obj2);
    // will return true, because TestServiceImpl is only instantiated once within the scope
    Console.WriteLine($"obj1 = obj2? {isEqual}");

    using IServiceScope scope2 = serviceProvider.CreateScope();
    var obj3 = scope2.ServiceProvider.GetService<TestServiceImpl>();
    var obj4 = scope2.ServiceProvider.GetService<TestServiceImpl>();
    isEqual = object.ReferenceEquals(obj3, obj4);
    // will return true, because TestServiceImpl is only instantiated once within the scope
    Console.WriteLine($"obj3 = obj4? {isEqual}");

    isEqual = object.ReferenceEquals(obj2, obj4);
    // will return false, because obj2 and obj4 belong to different scope
    Console.WriteLine($"obj2 = obj4? {isEqual}");
  }
}
