using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _03_v25_webapp_identity.Data.Account;
using _03_v25_webapp_identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QRCoder;

namespace _03_v25_webapp_identity.Pages.Account;

[Authorize]
public class AuthenticatorWithMFASetup : PageModel
{
    private readonly ILogger<AuthenticatorWithMFASetup> _logger;
    private readonly UserManager<User> _userManager;

    [BindProperty]
    public SetupMFAViewModel SetupMFAViewModel { get; set; } = new SetupMFAViewModel();
    [BindProperty]
    public bool Succeeded { get; set; } = false;

    public AuthenticatorWithMFASetup
    (
        ILogger<AuthenticatorWithMFASetup> logger,
        UserManager<User> userManager
    )
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            await _userManager.ResetAuthenticatorKeyAsync(user);
            var key = await _userManager.GetAuthenticatorKeyAsync(user);
            SetupMFAViewModel.Key = key ?? string.Empty;
            SetupMFAViewModel.QRCodeBytes = GenerateQRCodeBytes("my web app", SetupMFAViewModel.Key, user.Email ?? string.Empty);
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var user = await _userManager.GetUserAsync(User);
        if (user != null
            &&
            await _userManager.VerifyTwoFactorTokenAsync
            (
                user,
                _userManager.Options.Tokens.AuthenticatorTokenProvider,
                SetupMFAViewModel.SecurityCode
            )
        )
        {
            await _userManager.SetTwoFactorEnabledAsync(user, true);
            Succeeded = true;
        }
        else
        {
            ModelState.AddModelError("AuthenticatorSetup", "Something went wrong with the authenticator setup.");
        }

        return Page();
    }

    private Byte[] GenerateQRCodeBytes(string provider, string key, string userEmail)
    {
        var qrCodeGenerator = new QRCodeGenerator();
        var qrCodeData = qrCodeGenerator.CreateQrCode
        (
            $"otpauth://totp/{provider}:{userEmail}?secret={key}&issuer={provider}",
            QRCodeGenerator.ECCLevel.Q
        );

        var qrCode = new PngByteQRCode(qrCodeData);
        return qrCode.GetGraphic(20);
    }
}
