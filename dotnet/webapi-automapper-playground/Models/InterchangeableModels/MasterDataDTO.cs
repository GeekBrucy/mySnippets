using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.InterchangeableModels;

public class MasterDataDTO
{
  public int MasterDTOProp1 { get; set; }
  public int MasterDTOProp2 { get; set; }
  public BaseDataDTO DataDTO { get; set; }
}
