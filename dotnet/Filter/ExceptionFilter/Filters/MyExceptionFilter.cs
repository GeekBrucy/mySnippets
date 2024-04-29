using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionFilter.Filters;

public class MyExceptionFilter : IAsyncExceptionFilter
{
  private readonly IWebHostEnvironment _hostEnv;
  public MyExceptionFilter(IWebHostEnvironment hostEnv)
  {
    _hostEnv = hostEnv;
  }
  public Task OnExceptionAsync(ExceptionContext context)
  {
    /*
      context.Exception -> Exception Object
      context.ExceptionHandled -> If set to true, other ExceptionFilter will not execute
      context.Result -> Return to client
    */
    string msg;
    if (_hostEnv.IsDevelopment())
    {
      msg = context.Exception.ToString();
    }
    else
    {
      msg = "Unhandled Exception Occurred";
    }
    ObjectResult objectResult = new ObjectResult(new { code = 500, message = msg });
    context.Result = objectResult;
    context.ExceptionHandled = true;
    return Task.CompletedTask;
  }
}
