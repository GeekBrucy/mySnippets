using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Api.ActionFilters
{
    public class AsyncValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine(new string('@', 50));
            Console.WriteLine("AsyncValidationFilter");
            Console.WriteLine(new string('@', 50));
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument is IValidatableObject validatableObject)
                {
                    var validator = context.HttpContext.RequestServices
                        .GetService<IValidator<IValidatableObject>>();

                    if (validator != null)
                    {
                        var validationResult = await validator.ValidateAsync(validatableObject);
                        if (!validationResult.IsValid)
                        {
                            context.Result = new BadRequestObjectResult(validationResult.ToDictionary());
                            return;
                        }
                    }
                }
            }

            await next();
        }
    }
}