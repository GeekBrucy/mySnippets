using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _03_v25_webapp_identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _03_v25_webapp_identity.Pages.Account;

public class Register : PageModel
{
  [BindProperty]
  public RegisterViewModel RegisterViewModel { get; set; } = new RegisterViewModel();
  private readonly ILogger<Register> _logger;
  private readonly UserManager<IdentityUser> _userManager;

  public Register(ILogger<Register> logger, UserManager<IdentityUser> userManager)
  {
    _logger = logger;
    _userManager = userManager;
  }

  public void OnGet()
  {
  }

  public async Task<IActionResult> OnPostAsync()
  {
    if (!ModelState.IsValid) return Page();

    /*
      Validate email address is optional because `options.User.RequireUniqueEmail = true;` in the Program.cs takes care of this
    */

    // Try to create the user
    var user = new IdentityUser
    {
      Email = RegisterViewModel.Email,
      UserName = RegisterViewModel.Email,
    };

    var result = await _userManager.CreateAsync(user, RegisterViewModel.Password);

    if (result.Succeeded)
    {
      var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
      return Redirect
      (
        Url.PageLink
        (
          pageName: "/Account/ConfirmEmail",
          values: new { userId = user.Id, token = confirmationToken }
        )
        ??
        ""
      );
    }
    else
    {
      foreach (var error in result.Errors)
      {
        ModelState.AddModelError("Register", error.Description);
      }

      return Page();
    }
  }
}
