using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Dynamic.Json;

namespace MiddlewareInClass.Middlewares;

public class CheckPwdMiddleware
{
  private readonly RequestDelegate _next;
  public CheckPwdMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    string pwd = context.Request.Query["pwd"];

    if (pwd == "123")
    {
      if (context.Request.HasJsonContentType())
      {
        var reqStream = context.Request.BodyReader.AsStream();
        dynamic? jsonObj = DJson.Parse(reqStream);
        context.Items["BodyJson"] = jsonObj;
      }
      await _next(context);
    }
    else
    {
      context.Response.StatusCode = 401;
    }
  }
}
