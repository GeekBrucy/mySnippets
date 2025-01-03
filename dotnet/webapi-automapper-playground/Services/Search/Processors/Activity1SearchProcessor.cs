using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Models;

namespace webapi_automapper_playground.Services.Search.Processors;

// Curiously Recurring Template Pattern (CRTP) or self-referencing generic pattern.
public class Activity1SearchProcessor : BaseSearchProcessor
{
  protected override string WhoAmI { get; set; } = nameof(Activity1SearchProcessor);

  public override bool CanProcess(ExampleActivity exampleActivity)
  {
    return exampleActivity.Child1 != null;
  }
}
