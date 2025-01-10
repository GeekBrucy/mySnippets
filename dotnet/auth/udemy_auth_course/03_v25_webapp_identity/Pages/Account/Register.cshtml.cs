using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using _03_v25_webapp_identity.Models;
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
  private readonly IConfiguration _configuration;

  public Register(ILogger<Register> logger, UserManager<IdentityUser> userManager, IConfiguration configuration)
  {
    _logger = logger;
    _userManager = userManager;
    _configuration = configuration;
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
      var confirmationLink = Url.PageLink
        (
          pageName: "/Account/ConfirmEmail",
          values: new { userId = user.Id, token = confirmationToken }
        );
      var smtpSettings = new SmtpSettings();

      _configuration.GetSection("SMTPSettings").Bind(smtpSettings);

      var message = new MailMessage
      (
        smtpSettings.SmtpSender,
        user.Email,
        "Please confirm your email",
        $"Please click on this link to confirm your email address: {confirmationLink}"
      );

      using (var emailClient = new SmtpClient(smtpSettings.SmtpServer, 587))
      {
        emailClient.Credentials = new NetworkCredential
        (
          smtpSettings.SmtpUser,
          smtpSettings.SmtpPassword
        );

        await emailClient.SendMailAsync(message);
      }

      return RedirectToPage("/Account/Login");
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
