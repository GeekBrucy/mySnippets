using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_DDD_Feature_Demo.Models;

public class Product
{
  public int Id { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
  public CurrencyUnit CurrencyUnit { get; set; }
}
