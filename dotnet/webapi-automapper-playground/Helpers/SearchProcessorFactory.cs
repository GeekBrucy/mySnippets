using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Services.Feature1.Feature1Functions;

namespace webapi_automapper_playground.Helpers;

public class SearchProcessorFactory : ISearchProcessorFactory
{
  private readonly IServiceProvider _serviceProvider;
  public SearchProcessorFactory(
    IServiceProvider serviceProvider
  )
  {
    _serviceProvider = serviceProvider;
  }

  public IBaseSearchProcessor<T> GetFeatureFunction<T>() where T : class
  {
    return _serviceProvider.GetRequiredService<IBaseSearchProcessor<T>>();
  }
}
