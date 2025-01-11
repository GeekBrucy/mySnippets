using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _03_v25_webapp_identity.Data.Account;
using _03_v25_webapp_identity.Services;
using _03_v25_webapp_identity.Settings;
using _03_v25_webapp_identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace _03_v25_webapp_identity.Pages.Account;

public class LoginTwoFactor : PageModel
{
    private readonly ILogger<LoginTwoFactor> _logger;
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _emailService;
    private readonly SmtpSettings _smtpSettings;
    private readonly SignInManager<User> _signInManager;

    [BindProperty]
    public EmailMFA EmailMFA { get; set; } = new EmailMFA();

    public LoginTwoFactor
    (
        ILogger<LoginTwoFactor> logger,
        UserManager<User> userManager,
        IEmailService emailService,
        IOptionsSnapshot<SmtpSettings> options,
        SignInManager<User> signInManager
    )
    {
        _logger = logger;
        _userManager = userManager;
        _emailService = emailService;
        _smtpSettings = options.Value;
        _signInManager = signInManager;
    }

    public async Task OnGetAsync(string email, bool rememberMe)
    {
        var user = await _userManager.FindByEmailAsync(email);
        EmailMFA.SecurityCode = string.Empty;
        EmailMFA.RememberMe = rememberMe;
        // Generate the code
        var securityCode = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

        // Send to the user
        await _emailService.SendAsync
        (
            _smtpSettings.Sender,
            user.Email ?? string.Empty,
            "My Web App's OTP",
            $"Please use this code as the OTP: {securityCode}"
        );

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var result = await _signInManager.TwoFactorSignInAsync("Email", EmailMFA.SecurityCode, EmailMFA.RememberMe, false);
        if (result.Succeeded)
        {
            return RedirectToPage("/Index");
        }
        else
        {

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("Login2FA", "You are locked out.");
            }
            else
            {
                ModelState.AddModelError("Login2FA", "Failed to login.");
            }
        }
        return Page();
    }
}
