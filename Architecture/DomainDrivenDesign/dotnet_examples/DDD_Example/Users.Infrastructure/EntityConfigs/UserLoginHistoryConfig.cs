using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Users.Infrastructure.EntityConfigs;

public class UserLoginHistoryConfig : IEntityTypeConfiguration<UserLoginHistory>
{
  public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
  {
    builder.OwnsOne(x => x.PhoneNumber, pn =>
    {
      pn.Property(b => b.Number).HasMaxLength(20).IsUnicode(false);
    });

  }
}
