using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFConfigs.Models;

public class Order
{
  public long Id { get; set; }
  public string Name { get; set; }
  public string Address { get; set; }
  public Delivery Delivery { get; set; }
}
