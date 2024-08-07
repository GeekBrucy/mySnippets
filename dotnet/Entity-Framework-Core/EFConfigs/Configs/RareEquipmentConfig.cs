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
    // builder.Property(r => r.Owner).IsConcurrencyToken(); // when update the record with Id, the SQL will be `update RareEquipment set Owner = @p0 where Id = @p1 and Owner = @p2; <--- @p0 is the new value, @p2 is the old value

    builder.Property(r => r.RowVer).IsRowVersion();
  }
}
