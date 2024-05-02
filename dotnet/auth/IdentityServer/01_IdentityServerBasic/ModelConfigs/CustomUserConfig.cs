using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_IdentityServerBasic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_IdentityServerBasic.ModelConfigs;

public class CustomUserConfig : IEntityTypeConfiguration<CustomUser>
{
  public void Configure(EntityTypeBuilder<CustomUser> builder)
  {
    builder.ToTable("CustomUsers");
  }
}
