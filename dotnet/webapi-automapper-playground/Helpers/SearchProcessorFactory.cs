using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Services.Search.Processors;

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

  public IBaseSearchProcessor GetFeatureFunction()
  {
    return _serviceProvider.GetRequiredService<IBaseSearchProcessor>();
  }
}
