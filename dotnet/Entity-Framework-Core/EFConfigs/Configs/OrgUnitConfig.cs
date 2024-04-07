using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfigs.Configs;

public class OrgUnitConfig : IEntityTypeConfiguration<OrgUnit>
{
  public void Configure(EntityTypeBuilder<OrgUnit> builder)
  {
    builder.Property(o => o.Name).IsRequired().IsUnicode().HasMaxLength(100);
    builder.HasOne<OrgUnit>(u => u.Parent).WithMany(p => p.Children); // self ref
  }
}
