using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using reinvent_wheel_basic.Demo;
using reinvent_wheel_basic.Models.Settings;
using reinvent_wheel_basic.Providers;

internal class Program
{
  private static void Main(string[] args)
  {
    ConfigurationBuilder configBuilder = new ConfigurationBuilder();
    configBuilder.Add
    (
      new FxConfigSource
      {
        Path = "web.config"
      }
    );
    IConfigurationRoot configRoot = configBuilder.Build();
    ServiceCollection services = new ServiceCollection();
    services.AddScoped<Demo>();
    services.AddOptions()
      .Configure<WebConfig>(e => configRoot.Bind(e));

    using var sp = services.BuildServiceProvider();
    var demo = sp.GetRequiredService<Demo>();

    demo.Run();
  }
}