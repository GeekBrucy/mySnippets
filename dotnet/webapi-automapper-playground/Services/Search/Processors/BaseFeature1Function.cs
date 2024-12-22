using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Models;

namespace webapi_automapper_playground.Services.Search.Processors;

public abstract class BaseSearchProcessor : IBaseSearchProcessor
{
  protected abstract string WhoAmI { get; set; }
  public abstract bool CanProcess(ExampleActivity exampleActivity);
  public void Do()
  {
    Console.WriteLine($"Who Am I: {WhoAmI}");
  }
}
