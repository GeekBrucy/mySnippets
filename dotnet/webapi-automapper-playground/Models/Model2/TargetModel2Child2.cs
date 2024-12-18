using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.Model2;

public class TargetModel2Child2
{
  public int TargetModel2ChildProp1 { get; set; }
  public TargetModel2GrandChild1 TargetGrandChildren1 { get; set; }
}
