using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.DepartmentAScenario.DBModels;

public class DBMasterSubTypeOneExtra
{
  public int Child1ExtraId { get; set; }
  public DBMasterSubTypeOneChildTypeOne1? SubTypeOneChildTypeOne1 { get; set; }
  public DBMasterSubTypeOneChildTypeOne2? SubTypeOneChildTypeOne2 { get; set; }
  public DBMasterSubTypeOneChildTypeOne3? SubTypeOneChildTypeOne3 { get; set; }
  public DBMasterSubTypeOneChildTypeOne4? SubTypeOneChildTypeOne4 { get; set; }
  public DBMasterSubTypeOneChildTypeOne5? SubTypeOneChildTypeOne5 { get; set; }

  public ICollection<DBMasterSubTypeOneChildTypeTwo> ChildTypeTwos { get; set; }
}
