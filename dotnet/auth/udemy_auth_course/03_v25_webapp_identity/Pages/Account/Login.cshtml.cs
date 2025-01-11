using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _03_v25_webapp_identity.Data.Account;
using _03_v25_webapp_identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _03_v25_webapp_identity.Pages.Account;

public class Login : PageModel
{
    private readonly ILogger<Login> _logger;
    private readonly SignInManager<User> _signInManager;

    [BindProperty]
    public CredentialViewModel Credential { get; set; } = new CredentialViewModel();

    public Login(ILogger<Login> logger, SignInManager<User> signInManager)
    {
        _logger = logger;
        _signInManager = signInManager;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        var result = await _signInManager.PasswordSignInAsync
        (
            Credential.Email,
            Credential.Password,
            Credential.RememberMe,
            false
        );
        if (result.Succeeded)
        {
            return RedirectToPage("/Index");
        }
        else
        {
            if (result.RequiresTwoFactor)
            {
                return RedirectToPage
                (
                    "/Account/LoginTwoFactor",
                    new
                    {
                        Email = Credential.Email,
                        RememberMe = Credential.RememberMe
                    }
                );
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("Login", "You are locked out.");
            }
            else
            {
                ModelState.AddModelError("Login", "Failed to login.");
            }
        }

        return Page();
    }
}
