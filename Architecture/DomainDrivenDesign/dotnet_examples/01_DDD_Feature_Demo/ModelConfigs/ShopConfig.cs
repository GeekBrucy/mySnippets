using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_DDD_Feature_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DDD_Feature_Demo.ModelConfigs;

public class ShopConfig : IEntityTypeConfiguration<Shop>
{
  public void Configure(EntityTypeBuilder<Shop> builder)
  {
    builder.OwnsOne(s => s.Location); // owned entity
  }
}
