using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFConfigs.Configs;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
  public void Configure(EntityTypeBuilder<Order> builder)
  {
    builder.HasOne<Delivery>(o => o.Delivery).WithOne(d => d.Order)
      .HasForeignKey<Delivery>(d => d.OrderId); // this must be declared
  }
}
