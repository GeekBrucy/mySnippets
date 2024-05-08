using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_HostedServiceBasic.Services;

namespace _01_HostedServiceBasic.HostedServices;

public class HostedServiceDIShortLivedService : BackgroundService
{
  private IServiceScope _serviceScope;
  public HostedServiceDIShortLivedService(IServiceScopeFactory serviceScopeFactory)
  {
    _serviceScope = serviceScopeFactory.CreateScope();
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    try
    {
      Console.WriteLine($"{this.GetType()} Started...");
      Console.WriteLine($"Getting {nameof(TestService)}...");
      var testService = _serviceScope.ServiceProvider.GetRequiredService<TestService>();
      Console.WriteLine($"Calling {nameof(testService.Add)}...");
      Console.WriteLine($"Result: {testService.Add(1, 2)}");
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }
  public override void Dispose()
  {
    _serviceScope.Dispose();
    base.Dispose();
  }
}
