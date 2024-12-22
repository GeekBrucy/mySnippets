using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Helpers;
using webapi_automapper_playground.Models;
using webapi_automapper_playground.Services.Feature1;
using webapi_automapper_playground.Services.Feature1.Feature1Functions;

namespace webapi_automapper_playground.Services;

public class SearchService : ISearchService
{

  private readonly ISearchProcessorFactory _functionFactory;

  // for testing purpose
  private List<ExampleMaster> exampleMasters = new List<ExampleMaster>
  {
    new ExampleMaster
    {
      Activities = new List<ExampleActivity>
      {
        new ExampleActivity
        {
          Child1 = new ActivityExtend1
          {
            Child1Prop = 1
          }
        },
        new ExampleActivity
        {
          Child2 = new ActivityExtend2
          {
            Child2Prop = 2
          }
        }
      }
    }
  };

  public SearchService(
    ISearchProcessorFactory functionFactory
  )
  {
    _functionFactory = functionFactory;
  }



  public void Run()
  {
    _functionFactory.GetFeatureFunction<Activity1SearchProcessor>().Do();
  }
}
