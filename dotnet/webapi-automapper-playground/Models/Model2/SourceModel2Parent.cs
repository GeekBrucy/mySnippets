using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.Model2;

public class SourceModel2Parent
{
  public ICollection<SourceModel2Child> SourceChildren { get; set; }
}
