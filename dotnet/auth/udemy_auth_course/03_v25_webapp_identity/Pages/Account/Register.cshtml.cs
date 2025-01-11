using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

public class Register : PageModel
{
  [BindProperty]
  public RegisterViewModel RegisterViewModel { get; set; } = new RegisterViewModel();
  private readonly ILogger<Register> _logger;
  private readonly UserManager<User> _userManager;
  private readonly IEmailService _emailService;
  private readonly SmtpSettings _smtpSettings;

  public Register
  (
    ILogger<Register> logger,
    UserManager<User> userManager,
    IEmailService emailService,
    IOptionsSnapshot<SmtpSettings> options
  )
  {
    _logger = logger;
    _userManager = userManager;
    _emailService = emailService;
    _smtpSettings = options.Value;
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
    var user = new User
    {
      Email = RegisterViewModel.Email,
      UserName = RegisterViewModel.Email,
      Department = RegisterViewModel.Department,
      Position = RegisterViewModel.Position
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

      // for demo purpose, use the confirmation link directly
      return Redirect(confirmationLink ?? "");

      /////////////////////////////////////////////////////////////////
      // To Trigger the email confirmation flow, use the code below //
      ///////////////////////////////////////////////////////////////
      // await _emailService.SendAsync
      // (
      //   _smtpSettings.Sender,
      //   user.Email,
      //   "Please confirm your email",
      //   $"Please click on this link to confirm your email address: {confirmationLink}"
      // );

      // return RedirectToPage("/Account/Login");
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
