using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibModule2.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClassLibModule2;

public static class IServiceCollectionExtensions
{
  public static IServiceCollection AddModule2(this IServiceCollection service)
  {
    service.AddScoped<Service3>();
    service.AddScoped<Service4>();

    return service;
  }
}
