using IdentityServerConfig.Data;
using IdentityServerConfig.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServerConfig.Helpers;

public class DbInitializer
{
  public static async Task InitDbAndSeedUser(IServiceProvider provider)
  {
    using var scope = provider.CreateAsyncScope();
    var context = scope.ServiceProvider.GetService<MyDbContext>();
    context?.Database.Migrate();
    var userManager = scope.ServiceProvider.GetService<UserManager<CustomUser>>();
    if (userManager == null)
    {
      Console.WriteLine("No UserManager service");
    }
    else
    {
      if (context.Users.Any() == false) // seed users if there is no data
      {
        await SeedUser(userManager);
      }
    }
  }

  private static async Task SeedUser(UserManager<CustomUser> userManager)
  {
    IEnumerable<IdentityResult> results = new IdentityResult[]
    {
      await userManager.CreateAsync(new CustomUser { UserName = "userA" }, "123456"),
      await userManager.CreateAsync(new CustomUser { UserName = "userB" }, "123456"),
      await userManager.CreateAsync(new CustomUser { UserName = "userC" }, "123456"),
      await userManager.CreateAsync(new CustomUser { UserName = "userD" }, "123456"),
    };

    foreach (var failed in results.Where(r => r.Succeeded == false))
    {
      Console.WriteLine(new string('@', 20));
      Console.WriteLine(failed.Errors);
      Console.WriteLine(new string('@', 20));
      Console.WriteLine();
    }
  }
}
