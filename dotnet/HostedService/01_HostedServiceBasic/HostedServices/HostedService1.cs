using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_HostedServiceBasic.Services;

namespace _01_HostedServiceBasic.HostedServices;

public class HostedService1 : BackgroundService
{

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    try
    {
      Console.WriteLine("Hosted Service 1 started");
      await Task.Delay(3000);
      Console.WriteLine("Reading data...");
      await Task.Delay(3000);
      Console.WriteLine("Finish Reading data...");
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }

  }
}
