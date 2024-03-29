using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigServices.Interfaces;
using ConfigServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigServices.Extensions;

public static class IniFileConfigExtensions
{
  public static void AddIniFileConfigService(this IServiceCollection services, string filePath)
  {
    services.AddScoped<IConfigService>(s => new IniFileConfigService { FilePath = filePath });
  }
}
