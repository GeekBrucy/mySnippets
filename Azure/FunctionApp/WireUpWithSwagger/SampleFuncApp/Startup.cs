using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SampleFuncApp;
using Swashbuckle.AspNetCore.SwaggerGen;

[assembly: WebJobsStartup(typeof(Startup))]
namespace SampleFuncApp;

public class Startup : FunctionsStartup
{
  public override void Configure(IFunctionsHostBuilder builder)
  {
    builder.AddSwashBuckle(Assembly.GetExecutingAssembly(), opts =>
    {
      opts.AddCodeParameter = true;
      opts.Documents = new[]
      {
        new SwaggerDocument
        {
          Name = "v1",
          Title = "Swagger Document Test",
          Description = "Swagger UI for Azure Functions",
          Version = "v1"
        }
      };
      opts.ConfigureSwaggerGen = x =>
      {
        x.CustomOperationIds(apiDesc =>
        {
          return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : default(Guid).ToString();
        });
      };
    });
  }
}
