using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.InterchangeableModels;

public class PreviousDataDTO : BaseDataDTO
{
  public int PreviousMasterIdDTO { get; set; }
  public int PreviousSubIdDTO { get; set; }
}
