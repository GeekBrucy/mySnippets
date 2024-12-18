using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.Model2;

public class TargetModel2Parent1
{
  public ICollection<TargetModel2Child1> TargetChildren { get; set; }
}
