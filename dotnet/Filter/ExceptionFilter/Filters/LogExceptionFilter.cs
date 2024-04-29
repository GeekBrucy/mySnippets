using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionFilter.Filters;

public class LogExceptionFilter : IAsyncExceptionFilter
{
  /// <summary>
  /// The purpose of this filter is to log the errors, there is no need to set ExceptionHandled to true
  /// </summary>
  /// <param name="context"></param>
  /// <returns></returns>
  public Task OnExceptionAsync(ExceptionContext context)
  {
    // in real world, do not use file log because of the performance. Try some other logging tools
    return File.AppendAllTextAsync("./error.log", context.Exception.ToString());
  }
}
