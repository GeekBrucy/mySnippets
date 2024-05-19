using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_Basic.Middlewares;

public class RequestResponseLoggingMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

  public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task Invoke(HttpContext context)
  {
    var endpoint = context.GetEndpoint();
    // if it is not requesting an endpoint, forward the request and do nothing
    if (endpoint == null)
    {
      await _next(context);
      return;
    }

    var ipAddress = context.Connection.RemoteIpAddress;
    // Log the request
    _logger.LogInformation("Handling request from {IP}: {Method} {Path}", ipAddress, context.Request.Method, context.Request.Path);

    // Copy original response stream
    var originalBodyStream = context.Response.Body;

    using (var responseBody = new MemoryStream())
    {
      context.Response.Body = responseBody;

      // Call the next middleware in the pipeline
      await _next(context);

      // Log the response
      _logger.LogInformation("Handling Response from {ip}: {StatusCode}", ipAddress, context.Response.StatusCode);

      // Copy the contents of the new memory stream (which contains the response) to the original stream
      responseBody.Seek(0, SeekOrigin.Begin);
      await responseBody.CopyToAsync(originalBodyStream);
    }
  }
}
