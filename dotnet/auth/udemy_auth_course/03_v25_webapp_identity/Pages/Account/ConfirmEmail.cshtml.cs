using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _03_v25_webapp_identity.Data.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _03_v25_webapp_identity.Pages.Account;

public class ConfirmEmail : PageModel
{
    private readonly ILogger<ConfirmEmail> _logger;
    private readonly UserManager<User> _userManager;

    [BindProperty]
    public string Message { get; set; }

    public ConfirmEmail(ILogger<ConfirmEmail> logger, UserManager<User> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> OnGetAsync(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);

        Message = "Failed to validate email.";
        if (user == null)
        {

            return Page();
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            Message = "Email address is successfully confirmed, you can now try to login";
            return Page();
        }

        return Page();
    }
}
