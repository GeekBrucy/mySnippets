using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_DDD_Feature_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DDD_Feature_Demo.ModelConfigs;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.Property(p => p.CurrencyUnit).HasConversion<string>() // save enum as string
      .HasMaxLength(5);
  }
}
