using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.DepartmentAScenario.DBModels;

public class DBMaster
{
  public int MasterId { get; set; }

  public ICollection<DBMasterSubTypeOne>? ChildObject1s { get; set; }

}
