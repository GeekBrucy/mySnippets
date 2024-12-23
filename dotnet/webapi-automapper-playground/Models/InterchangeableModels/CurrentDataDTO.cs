using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.InterchangeableModels;

public class CurrentDataDTO : BaseDataDTO
{
  public string Prop1DTO { get; set; }
  public DateTime Prop2DTO { get; set; }
  public int Prop3DTO { get; set; }
}
