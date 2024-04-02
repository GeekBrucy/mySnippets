using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFConfigs.Models;

public class Person
{
  public long Id { get; set; }
  public string Name { get; set; }
  public int Age { get; set; }
  public string BirthPlace { get; set; }
}
