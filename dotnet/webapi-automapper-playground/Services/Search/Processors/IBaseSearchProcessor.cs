using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Models;

namespace webapi_automapper_playground.Services.Search.Processors;

public interface IBaseSearchProcessor
{
  void Do();
  bool CanProcess(ExampleActivity exampleActivity);
}
