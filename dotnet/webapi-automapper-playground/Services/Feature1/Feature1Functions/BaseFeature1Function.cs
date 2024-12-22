using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Services.Feature1.Feature1Functions;

public abstract class BaseFeature1Function<T> : IBaseFeature1Function<T>
{
  protected abstract string WhoAmI { get; set; }
  public void Do()
  {
    Console.WriteLine($"Who Am I: {WhoAmI}");
  }
}
