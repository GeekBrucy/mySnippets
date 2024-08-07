using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace SampleFuncApp;

public static class Swagger
{
  [SwaggerIgnore]
  [FunctionName("SwaggerUI")]
  public static Task<HttpResponseMessage> SwaggerUI(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "swagger/ui")] HttpRequestMessage req,
    [SwashBuckleClient] ISwashBuckleClient swashBuckleClient
  )
  {
    return Task.FromResult(swashBuckleClient.CreateSwaggerUIResponse(req, "swagger/json"));
  }

  [SwaggerIgnore]
  [FunctionName("SwaggerJson")]
  public static Task<HttpResponseMessage> SwaggerJson(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "swagger/json")] HttpRequestMessage req,
    [SwashBuckleClient] ISwashBuckleClient swashBuckleClient
  )
  {
    return Task.FromResult(swashBuckleClient.CreateSwaggerJsonDocumentResponse(req));
  }
}
