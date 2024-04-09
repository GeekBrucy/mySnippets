using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFConfigs.Models;

public class Teacher
{
  public long Id { get; set; }
  public string Name { get; set; }
  public List<Student> Students { get; set; } = new List<Student>();
}
