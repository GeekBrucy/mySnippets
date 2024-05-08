using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_hostedservice_export_data_interval.Data;
using Microsoft.EntityFrameworkCore;

namespace _02_hostedservice_export_data_interval.HostedServices;

public class ScheduledServices : BackgroundService
{
  private readonly IServiceScope _scope;
  private readonly MyDbContext _dbContext;
  public ScheduledServices(IServiceScopeFactory serviceScopeFactory)
  {
    _scope = serviceScopeFactory.CreateScope();
    _dbContext = _scope.ServiceProvider.GetService<MyDbContext>();
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    try
    {
      while (!stoppingToken.IsCancellationRequested)
      {
        long c = await _dbContext.Users.LongCountAsync();
        await File.WriteAllTextAsync("./test.txt", c.ToString());
        await Task.Delay(5000);
        Console.WriteLine($"Export suceeded at {DateTime.Now}");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }

  }

  public override void Dispose()
  {
    _scope.Dispose();
    base.Dispose();
  }
}
