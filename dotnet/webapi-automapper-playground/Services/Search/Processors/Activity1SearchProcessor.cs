using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Services.Feature1.Feature1Functions;

// Curiously Recurring Template Pattern (CRTP) or self-referencing generic pattern.
public class Activity1SearchProcessor : BaseSearchProcessor<Activity1SearchProcessor>
{
  protected override string WhoAmI { get; set; } = nameof(Activity1SearchProcessor);
}
