using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Models;

namespace webapi_automapper_playground.Services.Search.Processors;

public class Activity2SearchProcessor : BaseSearchProcessor
{
  protected override string WhoAmI { get; set; } = nameof(Activity2SearchProcessor);

  public override bool CanProcess(ExampleActivity exampleActivity)
  {
    return exampleActivity.Child2 != null;
  }
}
