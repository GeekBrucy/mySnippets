using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Data;
using EFConfigs.Models;

namespace EFDemoOneToOne;

public class Demo : IDisposable
{
  private readonly MyDbContext _ctx;

  public Demo()
  {
    _ctx = new MyDbContext();
  }

  public void Dispose()
  {
    _ctx.Dispose();
  }

  public async Task Create()
  {
    var order = new Order
    {
      Name = "Order 123",
      Address = "Somewhere"
    };

    var delivery = new Delivery
    {
      CompanyName = "Delivery Pty Ltd",
      Number = "213412312"
    };

    order.Delivery = delivery;
    _ctx.Orders.Add(order);

    await _ctx.SaveChangesAsync();
  }
}
