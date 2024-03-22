using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linq.Models;

public class Employee
{
  public string Name { get; set; }
  public int Age { get; set; }
  public string Gender { get; set; }
  public int Salary { get; set; }
  public override string ToString()
  {
    return $"Name = {Name}, Age = {Age}, Gender = {Gender}, Salary = {Salary}";
  }
}
