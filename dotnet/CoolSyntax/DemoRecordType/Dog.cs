using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRecordType;

public class Dog
{
  public int Id { get; set; }
  public string Name { get; set; }
  public Dog(int id, string name)
  {
    Id = id;
    Name = name;
  }
}
