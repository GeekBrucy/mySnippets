using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Entities;

namespace Users.Infrastructure.EntityConfigs;

public class UserAccessFailConfig : IEntityTypeConfiguration<UserAccessFail>
{
  public void Configure(EntityTypeBuilder<UserAccessFail> builder)
  {
    builder.Property("isLockOut");
  }
}
