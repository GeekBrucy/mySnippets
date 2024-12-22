using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Services.Feature1.Feature1Functions;

public abstract class BaseSearchProcessor<T> : IBaseSearchProcessor<T>
{
  protected abstract string WhoAmI { get; set; }
  public void Do()
  {
    Console.WriteLine($"Who Am I: {WhoAmI}");
  }
}
