using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfigs.Configs;

public class BookConfig : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.ToTable("T_Books");
  }
}
