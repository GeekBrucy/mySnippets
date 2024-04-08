using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFConfigs.Models;

public class OrgUnit
{
  public long Id { get; set; }
  public string Name { get; set; }
  public OrgUnit? Parent { get; set; }
  public List<OrgUnit> Children { get; set; } = new List<OrgUnit>();

  public override string ToString()
  {
    return $"Id={Id}, Name={Name}";
  }
}
