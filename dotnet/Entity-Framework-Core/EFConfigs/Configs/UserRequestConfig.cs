using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using EFConfigs.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfigs.Configs;

public class UserRequestConfig : IEntityTypeConfiguration<UserRequest>
{
  public void Configure(EntityTypeBuilder<UserRequest> builder)
  {
    builder.Property(ur => ur.Type)
      .HasConversion
      (
        ur => ur.ToString(),
        ur => (UserRequestType)Enum.Parse(typeof(UserRequestType), ur)
      );
    builder.Property(ur => ur.Status)
      .HasConversion
      (
        ur => ur.ToString(),
        ur => (UserRequestStatus)Enum.Parse(typeof(UserRequestStatus), ur)
      );

    // we decided not to set the User -> UserRequest direction, so no arguments is needed in the WithMany()
    builder.HasOne<User>(ur => ur.RequestedBy).WithMany().IsRequired();
    builder.HasOne<User>(ur => ur.ApprovedBy).WithMany();
  }
}
