using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_IdentityServerBasic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_IdentityServerBasic.ModelConfigs;

public class CustomRoleConfig : IEntityTypeConfiguration<CustomRole>
{
  public void Configure(EntityTypeBuilder<CustomRole> builder)
  {
    builder.ToTable("CustomRoles");
  }
}
