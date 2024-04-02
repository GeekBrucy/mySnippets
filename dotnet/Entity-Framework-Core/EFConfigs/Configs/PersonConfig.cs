using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfigs.Configs;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
  public void Configure(EntityTypeBuilder<Person> builder)
  {
    builder.ToTable("T_Persons");
  }
}
