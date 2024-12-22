using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Services.Feature1.Feature1Functions;

// Curiously Recurring Template Pattern (CRTP) or self-referencing generic pattern.
public class Feature1Function1 : BaseFeature1Function<Feature1Function1>
{
  protected override string WhoAmI { get; set; } = nameof(Feature1Function1);
}
