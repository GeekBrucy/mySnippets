using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigServices.Interfaces;
using ConfigServices.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigServices.Extensions;

public static class LayeredConfigExtensions
{
  public static void AddLayeredConfig(this IServiceCollection services)
  {
    services.AddScoped<IConfigReader, LayeredConfigReader>();
  }
}
