using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_IdentityServerBasic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _01_IdentityServerBasic.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoController : ControllerBase
{
  private readonly UserManager<CustomUser> _userManager;
  private readonly RoleManager<CustomRole> _roleManager;
  public DemoController(UserManager<CustomUser> userManager, RoleManager<CustomRole> roleManager)
  {
    _userManager = userManager;
    _roleManager = roleManager;
  }

  [HttpPost]
  public async Task<ActionResult<IdentityResult>> CreateRole(string roleName)
  {
    if (!await _roleManager.RoleExistsAsync(roleName))
    {
      CustomRole newRole = new CustomRole { Name = roleName };
      Console.WriteLine("creating role");
      var result = await _roleManager.CreateAsync(newRole);
      if (result.Succeeded == false)
      {
        return BadRequest(result.Errors);
      }
      else
      {
        return Ok("created role");
      }
    }

    return IdentityResult.Success;
  }

  [HttpPost]
  public async Task<ActionResult<IdentityResult>> CreateUser(string userName)
  {
    CustomUser customUser = await _userManager.FindByNameAsync(userName);
    if (customUser == null)
    {
      customUser = new CustomUser { UserName = userName };
      var result = await _userManager.CreateAsync(customUser, "123456");
      if (result.Succeeded == false)
      {
        return BadRequest(result.Errors);
      }
      else
      {
        return Ok("created user");
      }
    }
    return BadRequest("user exists");
  }

  [HttpPost]
  public async Task<ActionResult<IdentityResult>> AssignUserRole(string userName, string roleName)
  {
    if (!await _roleManager.RoleExistsAsync(roleName))
    {
      return NotFound($"{roleName} role not found");
    }
    CustomUser user = await _userManager.FindByNameAsync(userName);
    if (user == null)
    {
      return NotFound($"No user with name '{userName}'");
    }

    if (await _userManager.IsInRoleAsync(user, roleName))
    {
      return BadRequest($"{userName} already has {roleName} role");
    }

    var result = await _userManager.AddToRoleAsync(user, roleName);
    if (result.Succeeded == false)
    {
      return BadRequest(result.Errors);
    }
    else
    {
      return Ok("role assigned");
    }
  }

  [HttpPost]
  public async Task<ActionResult<IdentityResult>> CheckUserLogin(string userName, string password)
  {
    CustomUser user = await _userManager.FindByNameAsync(userName);
    if (user == null)
    {
      return NotFound($"No user with name '{userName}'"); // not found will introduce security issue, do not use in production
    }

    if (await _userManager.IsLockedOutAsync(user))
    {
      return BadRequest("User locked");
    }

    if (await _userManager.CheckPasswordAsync(user, password))
    {
      await _userManager.ResetAccessFailedCountAsync(user); // reset failed login count
      return Ok("Login successfully");
    }
    else
    {
      await _userManager.AccessFailedAsync(user); // record failed login count
      return BadRequest("Invalid operation");
    }

  }
  [HttpPost]
  public async Task<ActionResult> ResetPasswordRequest(string userName)
  {
    CustomUser user = await _userManager.FindByNameAsync(userName);
    if (user == null)
    {
      return NotFound($"No user with name '{userName}'"); // not found will introduce security issue, do not use in production
    }

    string token = await _userManager.GeneratePasswordResetTokenAsync(user);

    Console.WriteLine($"reset token: {token}");

    return Ok();
  }

  [HttpPut]
  public async Task<ActionResult> ResetPassword(string userName, string token, string newPassword)
  {
    CustomUser user = await _userManager.FindByNameAsync(userName);
    if (user == null)
    {
      return NotFound($"No user with name '{userName}'"); // not found will introduce security issue, do not use in production
    }

    var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
    if (result.Succeeded)
    {
      await _userManager.ResetAccessFailedCountAsync(user);
      return Ok("Password is reset");
    }
    else
    {
      await _userManager.AccessFailedAsync(user);
      return BadRequest("Reset fail");
    }
  }
}
