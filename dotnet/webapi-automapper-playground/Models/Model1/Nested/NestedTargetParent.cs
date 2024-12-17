using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.Model1.Nested;

public class NestedTargetParent
{
  public string TargetParentProp { get; set; }
  public NesteTargetChild1 TargetChild1 { get; set; }
  public IEnumerable<NestedSourceChild> TargetChildren1 { get; set; }
}
