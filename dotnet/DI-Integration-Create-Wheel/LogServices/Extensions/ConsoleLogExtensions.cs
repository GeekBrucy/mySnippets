using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogServices.Interfaces;
using LogServices.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace LogServices.Extensions;

public static class ConsoleLogExtensions
{
  public static void AddConsoleLogService(this IServiceCollection services)
  {
    services.AddScoped<ILogProvider, ConsoleLogProvider>();
  }
}
