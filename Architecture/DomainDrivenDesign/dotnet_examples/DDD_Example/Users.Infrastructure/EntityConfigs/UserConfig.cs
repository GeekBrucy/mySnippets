using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Users.Infrastructure.EntityConfigs;

public class UserConfig : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.OwnsOne(x => x.PhoneNumber, pn =>
    {
      pn.Property(b => b.Number).HasMaxLength(20).IsUnicode(false);
    });

    builder.HasOne(b => b.AccessFail).WithOne(f => f.User)
      .HasForeignKey<UserAccessFail>(f => f.UserId);

    builder.Property("passwordHash").HasMaxLength(100).IsUnicode(false);
  }
}
