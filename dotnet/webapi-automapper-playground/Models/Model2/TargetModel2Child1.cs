using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.Model2;

public class TargetModel2Child1
{
  public int TargetModel2ChildProp1 { get; set; }
  public ICollection<TargetModel2GrandChild1> TargetGrandChildren1 { get; set; } = new Collection<TargetModel2GrandChild1>();
  public ICollection<TargetModel2GrandChild2> TargetGrandChildren2 { get; set; } = new Collection<TargetModel2GrandChild2>();
}
