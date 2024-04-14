using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfigs.Configs;

public class RareEquipmentConfig : IEntityTypeConfiguration<RareEquipment>
{
  public void Configure(EntityTypeBuilder<RareEquipment> builder)
  {
    builder.Property(r => r.Owner).IsConcurrencyToken();
  }
}
