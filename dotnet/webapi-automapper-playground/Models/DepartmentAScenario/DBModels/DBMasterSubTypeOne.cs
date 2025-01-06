using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.DepartmentAScenario.DBModels;

public class DBMasterSubTypeOne
{
  public int MasterChild1Id { get; set; }

  public DBMasterSubTypeOneExtra? Child1Extra { get; set; }
}
