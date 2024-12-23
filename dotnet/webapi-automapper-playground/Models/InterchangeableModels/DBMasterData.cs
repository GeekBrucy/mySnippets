
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.InterchangeableModels;

public class DBMasterData
{
  public int MasterProp1 { get; set; }
  public int MasterProp2 { get; set; }
  public int? PreviousMasterId { get; set; }
  public int? PreviousSubId { get; set; }

  public DBData? Data { get; set; }
}
