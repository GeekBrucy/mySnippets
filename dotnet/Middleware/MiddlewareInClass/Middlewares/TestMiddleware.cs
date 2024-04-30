using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareInClass.Middlewares;

public class TestMiddleware
{
  private readonly RequestDelegate _next;
  public TestMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    await context.Response.WriteAsync("TextMiddleware start<br />");
    await _next.Invoke(context);
    await context.Response.WriteAsync("TextMiddleware end<br />");
  }
}
