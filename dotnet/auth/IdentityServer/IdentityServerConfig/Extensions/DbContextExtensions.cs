using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerConfig.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServerConfig.Extensions;

public static class DbContextExtensions
{
  public static IServiceCollection AddDbContextConfig(
    this IServiceCollection services,
    Action<DbContextOptionsBuilder> dbContextBuilder
  )
  {
    services.AddDbContext<MyDbContext>(dbContextBuilder);
    return services;
  }
}
