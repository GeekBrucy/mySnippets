using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Services.Search.Processors;

namespace webapi_automapper_playground.Helpers;

public interface ISearchProcessorFactory
{
  IBaseSearchProcessor GetFeatureFunction();
}
