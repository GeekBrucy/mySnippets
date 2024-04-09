using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfigs.Configs;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
  public void Configure(EntityTypeBuilder<Student> builder)
  {
    builder.HasMany<Teacher>(s => s.Teachers).WithMany(t => t.Students);
    // .UsingEntity(r => r.ToTable("R_Students_Teachers"))
  }
}
