using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Services.Feature1;
using webapi_automapper_playground.Services.Feature1.Feature1Functions;

namespace webapi_automapper_playground.Helpers;

public interface ISearchProcessorFactory
{
  IBaseSearchProcessor<T> GetFeatureFunction<T>() where T : class;
}
