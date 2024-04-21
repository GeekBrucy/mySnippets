using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using ClassLibModule1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClassLibModule1;

public static class IServiceCollectionExtensions
{
  public static IServiceCollection AddModule1(this IServiceCollection service)
  {
    service.AddScoped<Service1>();
    service.AddScoped<Service2>();

    return service;
  }
}
