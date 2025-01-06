using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.DepartmentAScenario.DBModels;

public class DBMasterSubTypeOneChildTypeTwo
{
  public ICollection<DBMasterSubTypeOneChildTypeTwoGrandChild> ChildTypeTwoGrandChildren { get; set; }
}
