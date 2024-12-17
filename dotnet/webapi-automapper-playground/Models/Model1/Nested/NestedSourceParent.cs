using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.Model1.Nested;

public class NestedSourceParent
{
  public string SourceParentProp { get; set; }
  public NestedSourceChild1 SourceChild1 { get; set; }
  public IEnumerable<NestedSourceChild> SourceChildren1 { get; set; }
}
