using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServerConfig.Constants;
using IdentityServerConfig.Helpers;
using IdentityServerConfig.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _02_JWT.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoRevokeJWTController : ControllerBase
{
  private readonly UserManager<CustomUser> _userManager;
  private readonly JwtSettings _jwtSettings;
  public DemoRevokeJWTController(UserManager<CustomUser> userManager, IOptionsSnapshot<JwtSettings> jwtSettings)
  {
    _userManager = userManager;
    _jwtSettings = jwtSettings.Value;
  }

  [HttpPost]
  [AllowAnonymous]
  public async Task<ActionResult<string>> Login(string userName, string password)
  {
    var user = await _userManager.FindByNameAsync(userName);
    if (user == null)
    {
      return BadRequest("Wrong username or password");
    }

    var success = await _userManager.CheckPasswordAsync(user, password);
    if (!success)
    {
      return BadRequest("Wrong username or password");
    }

    await _userManager.ResetAccessFailedCountAsync(user);

    // increase the JwtVersion
    user.JwtVersion++;
    await _userManager.UpdateAsync(user);

    List<Claim> claims = new List<Claim>
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
      new Claim(ClaimTypes.Name, user.UserName),
      new Claim(ClaimTypes.Role, "admin"),
      new Claim(DemoProjConstants.Jwt.JwtVersionClaimKey, user.JwtVersion.ToString()), // add jwt version to the claim
    };
    return Ok(JwtHelper.JwtGenerator(_jwtSettings.SecKey, claims));
  }
}
