using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace AzureADWebAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class DemoController : ControllerBase
{
  [HttpGet]
  public bool Test()
  {
    var user = User.Identity.Name;
    Console.WriteLine($"User: {user}");
    return true;
  }
}
