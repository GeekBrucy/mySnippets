using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfigs.Configs;

public class ArticleConfig : IEntityTypeConfiguration<Article>
{
  public void Configure(EntityTypeBuilder<Article> builder)
  {
    builder.Property(a => a.Content).IsRequired().IsUnicode();
    builder.Property(a => a.Title).IsRequired().IsUnicode().HasMaxLength(255);
  }
}
