using json_config_DI.Controllers;
using json_config_DI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
  private static void Main(string[] args)
  {
    ServiceCollection services = new ServiceCollection();
    ConfigurationBuilder configBuilder = new ConfigurationBuilder();

    configBuilder.AddJsonFile
    (
      "config.json",
      optional: true,
      reloadOnChange: true
    );
    IConfigurationRoot configRoot = configBuilder.Build();

    // this is the key step of binding config to class and inject
    services.AddOptions()
      .Configure<Config>(e => configRoot.Bind(e))
      .Configure<Proxy>(e => configRoot.GetSection("proxy").Bind(e));

    services.AddScoped<TestController>();
    services.AddScoped<Test2Controller>();

    using var sp = services.BuildServiceProvider();

    var testController = sp.GetRequiredService<TestController>();
    var test2Controller = sp.GetRequiredService<Test2Controller>();

    testController.Test();
    test2Controller.Test();
  }
}