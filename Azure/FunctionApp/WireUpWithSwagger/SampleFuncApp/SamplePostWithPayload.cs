using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SampleFuncApp.Models;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SampleFuncApp
{
    public static class SamplePostWithPayload
    {
        [FunctionName("SamplePostWithPayload")]
        public static async Task<IActionResult> Run(
            [RequestBodyType(typeof(Person), "The Person To Create")] // Describes the Body
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var bodyStr = await req.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<Person>(bodyStr);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, new ValidationContext(obj, null, null), results, true);

            if (isValid)
            {
                return new OkObjectResult(obj);
            }

            return new BadRequestObjectResult(results);
        }
    }
}
