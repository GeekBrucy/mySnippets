using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Users.WebAPI.Attributes;

namespace Users.WebAPI.Filters;

public class UnitOfWorkFilter : IAsyncActionFilter
{
  public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
    var result = await next();
    if (result.Exception != null)
    {
      return;
    }
    var actionDesc = context.ActionDescriptor as ControllerActionDescriptor;

    var uowAttr = actionDesc.MethodInfo.GetCustomAttribute<UnitOfWorkAttribute>();

    if (uowAttr == null)
    {
      return;
    }
    foreach (var dbCtxType in uowAttr.DbContextTypes)
    {
      var dbCtx = context.HttpContext.RequestServices.GetService(dbCtxType) as DbContext; // get db context instance

      if (dbCtx != null)
      {
        Console.WriteLine("before save changes");
        await dbCtx.SaveChangesAsync();
      }
    }
  }
}
