using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebAPIConfig.Interfaces;
using DemoWebAPIConfig.Models.Settings;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPIConfig.Data;

public class MyDbContext : DbContext, IGetAppSettingsFromDb
{
  public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
  {
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
  }

  public IDictionary<string, string?> GetSettings()
  {
    return AppSettings.ToDictionary(a => a.Name, a => a.Value, StringComparer.OrdinalIgnoreCase);
  }

  public DbSet<AppSetting> AppSettings => Set<AppSetting>();
}
