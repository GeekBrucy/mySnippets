using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebAPIConfig.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoWebAPIConfig.DBModelConfig;

public class AppSettingConfig : IEntityTypeConfiguration<AppSetting>
{
  public void Configure(EntityTypeBuilder<AppSetting> builder)
  {
    builder.HasKey(a => a.Name);
  }
}
