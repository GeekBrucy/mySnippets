using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_DDD_Feature_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_DDD_Feature_Demo.ModelConfigs;

public class BlogConfig : IEntityTypeConfiguration<Blog>
{
  public void Configure(EntityTypeBuilder<Blog> builder)
  {
    builder.OwnsOne(e => e.Title, opt =>
    {
      opt.Property(o => o.Chinese).HasMaxLength(255);
      opt.Property(o => o.English).HasColumnType("varchar(255)");
    });
    builder.OwnsOne(e => e.Body, opt =>
    {
      opt.Property(o => o.English).HasColumnType("varchar(max)");
    });
  }
}
