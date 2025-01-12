using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _03_v25_webapp_identity.Data.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _03_v25_webapp_identity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
  private readonly SignInManager<User> _signInManager;

  public AccountController(SignInManager<User> signInManager)
  {
    _signInManager = signInManager;
  }

  public async Task<IActionResult> ExternalLoginCallback()
  {
    Console.WriteLine(new string('@', 50));
    Console.WriteLine("AccountController:ExternalLoginCallback");
    Console.WriteLine(new string('@', 50));
    var loginInfo = await _signInManager.GetExternalLoginInfoAsync();
    if (loginInfo != null)
    {
      Console.WriteLine(new string('@', 50));
      Console.WriteLine("has login info");
      Console.WriteLine(new string('@', 50));
      var emailClaim = loginInfo.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
      var nameClaim = loginInfo.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);

      if (emailClaim != null && nameClaim != null)
      {
        var user = new User { Email = emailClaim.Value, UserName = nameClaim.Value };
        await _signInManager.SignInAsync(user, false);
        Console.WriteLine(new string('@', 50));
        Console.WriteLine("after sign in");
        Console.WriteLine(new string('@', 50));
      }
    }

    return RedirectToPage("/Index");
  }
}
