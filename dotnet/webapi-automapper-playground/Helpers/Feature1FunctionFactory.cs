using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Services.Feature1.Feature1Functions;

namespace webapi_automapper_playground.Helpers;

public class Feature1FunctionFactory : IFeature1FunctionFactory
{
  private readonly IServiceProvider _serviceProvider;
  public Feature1FunctionFactory(
    IServiceProvider serviceProvider
  )
  {
    _serviceProvider = serviceProvider;
  }

  public IBaseFeature1Function<T> GetFeatureFunction<T>() where T : class
  {
    return _serviceProvider.GetRequiredService<IBaseFeature1Function<T>>();
  }
}
