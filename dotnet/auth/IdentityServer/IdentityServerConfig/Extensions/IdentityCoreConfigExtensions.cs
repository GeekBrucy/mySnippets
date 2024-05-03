using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerConfig.Data;
using IdentityServerConfig.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServerConfig.Extensions;

public static class IdentityCoreConfigExtensions
{
  public static IServiceCollection AddIdentityCoreServices(this IServiceCollection services)
  {
    services.AddDataProtection();
    // do not use AddIdentity in webapi, because that's for MVC
    services.AddIdentityCore<CustomUser>(opt =>
    {
      // the following rules are for testing purpose
      opt.Password.RequireDigit = false;
      opt.Password.RequireLowercase = false;
      opt.Password.RequireNonAlphanumeric = false;
      opt.Password.RequireUppercase = false;
      opt.Password.RequiredLength = 6;
      opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider; // without this, the token will be very long
      opt.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
    });
    var idBuilder = new IdentityBuilder(typeof(CustomUser), typeof(CustomRole), services);
    idBuilder.AddEntityFrameworkStores<MyDbContext>()
        .AddDefaultTokenProviders()
        .AddRoleManager<RoleManager<CustomRole>>()
        .AddUserManager<UserManager<CustomUser>>();
    return services;
  }
}
