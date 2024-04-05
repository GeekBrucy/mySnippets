using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfigs.Configs;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
  public void Configure(EntityTypeBuilder<Comment> builder)
  {
    builder.Property(a => a.Content).IsRequired().IsUnicode();
    builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments);
  }
}
