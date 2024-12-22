using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_automapper_playground.Helpers;
using webapi_automapper_playground.Models;
using webapi_automapper_playground.Services.Feature1;
using webapi_automapper_playground.Services.Search.Processors;

namespace webapi_automapper_playground.Services;

public class SearchService : ISearchService
{
  private readonly IEnumerable<IBaseSearchProcessor> _searchProcessors;

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
    IEnumerable<IBaseSearchProcessor> searchProcessors
  )
  {
    _searchProcessors = searchProcessors;
  }

  public void Run()
  {
    foreach (var master in exampleMasters)
    {
      foreach (var activity in master.Activities)
      {
        foreach (var processor in from processor in _searchProcessors
                                  where processor.CanProcess(activity)
                                  select processor)
        {
          processor.Do();
        }
      }
    }
  }
}
