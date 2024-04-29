using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter.Filters;

public class MyActionFilter : IAsyncActionFilter
{
  public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
    Console.WriteLine("MyActionFilter: Before execution");
    ActionExecutedContext r = await next();
    if (r.Exception != null)
    {
      Console.WriteLine("MyActionFilter: Exception occurred");
    }
    else
    {
      Console.WriteLine("MyActionFilter: Executed");
    }
  }
}
