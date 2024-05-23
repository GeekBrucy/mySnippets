using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_DDD_Feature_Demo.Models;

public class Shop
{
  public int Id { get; set; }
  public string Name { get; set; }
  public Geo Location { get; set; }
}
