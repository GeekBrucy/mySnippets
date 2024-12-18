using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.Model2;

public class TargetModel2Parent2
{
  public ICollection<TargetModel2Child2> TargetChildren { get; set; }
}
