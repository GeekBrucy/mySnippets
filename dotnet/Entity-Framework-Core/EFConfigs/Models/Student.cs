using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFConfigs.Models;

public class Student
{
  public long Id { get; set; }
  public string Name { get; set; }
  public List<Teacher> Teachers { get; set; } = new List<Teacher>();
}
