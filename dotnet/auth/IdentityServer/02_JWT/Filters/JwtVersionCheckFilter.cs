using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServerConfig.Constants;
using IdentityServerConfig.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _02_JWT.Filters;

public class JwtVersionCheckFilter : IAsyncActionFilter
{
  private readonly UserManager<CustomUser> _userManager;

  public JwtVersionCheckFilter(UserManager<CustomUser> userManager)
  {
    _userManager = userManager;
  }

  public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
    ControllerActionDescriptor? controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

    if (controllerActionDescriptor == null)
    {
      await next();
      return;
    }

    if (controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any())
    {
      Console.WriteLine("here");
      await next();
      return;
    }

    var claimJwtVer = context.HttpContext.User.FindFirst(DemoProjConstants.Jwt.JwtVersionClaimKey);
    if (claimJwtVer == null)
    {
      context.Result = new ObjectResult($"No {DemoProjConstants.Jwt.JwtVersionClaimKey} in payload") // just say invalid token in PROD maybe
      { StatusCode = 400 };
      return;
    }
    var claimUserId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
    long jwtVerFromClient = Convert.ToInt64(claimJwtVer.Value);
    // TODO: can use cache to avoid querying the db every request
    var user = await _userManager.FindByIdAsync(claimUserId.Value);
    if (user == null)
    {
      context.Result = new ObjectResult($"No user found")
      { StatusCode = 400 };
      return;
    }

    if (user.JwtVersion > jwtVerFromClient)
    {
      context.Result = new ObjectResult($"stale claim")
      { StatusCode = 400 };
      return;
    }
    await next();
  }
}
