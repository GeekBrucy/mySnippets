using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServerConfig.Helpers;
using IdentityServerConfig.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _02_JWT.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoAuthenticationController : ControllerBase
{
  private readonly UserManager<CustomUser> _userManager;
  private readonly JwtSettings _jwtSettings;
  public DemoAuthenticationController(UserManager<CustomUser> userManager, IOptionsSnapshot<JwtSettings> jwtSettings)
  {
    _userManager = userManager;
    _jwtSettings = jwtSettings.Value;
  }

  [HttpPost]
  [AllowAnonymous]
  public async Task<ActionResult<string>> FakeLogin(string userName, string password)
  {
    Console.WriteLine(_jwtSettings.SecKey);
    var user = await _userManager.FindByNameAsync(userName);
    var success = await _userManager.CheckPasswordAsync(user, password);
    if (!success)
    {
      return BadRequest("Failed");
    }
    List<Claim> claims = new List<Claim>
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
      new Claim(ClaimTypes.Name, user.UserName),
      new Claim(ClaimTypes.Role, "admin"),
    };
    return Ok(JwtHelper.JwtGenerator(_jwtSettings.SecKey, claims));
  }

  [HttpGet]
  [Authorize]
  public void ActionRequiresAuth()
  {
    var claim = User.FindFirst(ClaimTypes.Name).Value;
    string userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
    IEnumerable<Claim> roleClaims = User.FindAll(ClaimTypes.Role);
    string roleNames = string.Join(", ", roleClaims.Select(c => c.Value));
  }

  [HttpGet]
  [Authorize(Roles = "admin")]
  public void ActionRequiresAdmin()
  {
    Console.WriteLine("OK");
  }
}
