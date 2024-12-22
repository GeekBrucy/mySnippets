using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Helpers;
using webapi_automapper_playground.Services.Feature1;
using webapi_automapper_playground.Services.Feature1.Feature1Functions;

namespace webapi_automapper_playground.Services;

public class Feature1Service : IFeature1Service
{

  private readonly IFeature1FunctionFactory _functionFactory;
  public Feature1Service(
    IFeature1FunctionFactory functionFactory
  )
  {
    _functionFactory = functionFactory;
  }

  public void Run()
  {
    _functionFactory.GetFeatureFunction<Feature1Function1>().Do();
  }
}
