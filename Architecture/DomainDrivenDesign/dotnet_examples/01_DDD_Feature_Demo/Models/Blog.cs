using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_DDD_Feature_Demo.Models;

public class Blog
{
  public int Id { get; set; }
  public Localize Title { get; set; }
  public Localize Body { get; set; }
}
