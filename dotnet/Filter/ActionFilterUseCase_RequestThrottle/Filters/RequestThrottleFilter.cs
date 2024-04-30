using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace ActionFilterUseCase_RequestThrottle.Filters;

public class RequestThrottleFilter : IAsyncActionFilter
{
  private readonly IMemoryCache _memCache;
  public RequestThrottleFilter(IMemoryCache memCache)
  {
    _memCache = memCache;
  }
  public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
    string removeIP = context.HttpContext.Connection.RemoteIpAddress.ToString();
    string cacheKey = $"LastVisitTick_{removeIP}";
    long? lastTick = _memCache.Get<long?>(cacheKey);
    if (lastTick == null || Environment.TickCount64 - lastTick > 1000)
    {
      _memCache.Set(cacheKey, Environment.TickCount64, TimeSpan.FromSeconds(10));
      return next();
    }

    context.Result = new ContentResult
    {
      StatusCode = 429,
      Content = "Ooops, Too many requests"
    };
    return Task.CompletedTask;
  }
}
