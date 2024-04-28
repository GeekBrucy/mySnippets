using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLib.ModelConfig;

public class BookConfig : IEntityTypeConfiguration<Book>
{
  public void Configure(EntityTypeBuilder<Book> builder)
  {
    // include special settings here
  }
}
