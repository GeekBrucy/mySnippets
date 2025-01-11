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

public class LoginTwoFactorWithAuthenticator : PageModel
{
    private readonly ILogger<LoginTwoFactorWithAuthenticator> _logger;
    private readonly SignInManager<User> _signInManager;

    [BindProperty]
    public AuthenticatorMFAViewModel AuthenticatorMFA { get; set; } = new AuthenticatorMFAViewModel();

    public LoginTwoFactorWithAuthenticator
    (
        ILogger<LoginTwoFactorWithAuthenticator> logger,
        SignInManager<User> signInManager
    )
    {
        _logger = logger;
        _signInManager = signInManager;
    }

    public void OnGet(bool rememberMe)
    {
        AuthenticatorMFA.SecurityCode = string.Empty;
        AuthenticatorMFA.RememberMe = rememberMe;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        /*
            How does the app know which user to login?

            There is a cookie at the front end: Identity.TwoFactorUserId. It will come with the request and then the TwoFactorAuthenticatorSignInAsync will use the cookie to know which user it is trying to authenticate
        */
        var result = await _signInManager
            .TwoFactorAuthenticatorSignInAsync(AuthenticatorMFA.SecurityCode, AuthenticatorMFA.RememberMe, false);
        if (result.Succeeded)
        {
            return RedirectToPage("/Index");
        }
        else
        {
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("Authenticator 2FA", "You are locked out.");
            }
            else
            {
                ModelState.AddModelError("Authenticator 2FA", "Failed to login.");
            }
            return Page();
        }
    }
}
