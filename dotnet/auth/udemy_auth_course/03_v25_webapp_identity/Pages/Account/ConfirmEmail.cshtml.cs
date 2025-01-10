using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _03_v25_webapp_identity.Pages.Account;

public class ConfirmEmail : PageModel
{
    private readonly ILogger<ConfirmEmail> _logger;
    private readonly UserManager<IdentityUser> _userManager;

    [BindProperty]
    public string Message { get; set; }

    public ConfirmEmail(ILogger<ConfirmEmail> logger, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> OnGetAsync(string userId, string token)
    {
        Console.WriteLine($"userId: {userId}");
        Console.WriteLine($"token: {token}");
        var user = await _userManager.FindByIdAsync(userId);

        Message = "Failed to validate email.";
        if (user == null)
        {

            return Page();
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        Console.WriteLine($"result.Succeeded: {result.Succeeded}");
        if (result.Succeeded)
        {
            Message = "Email address is successfully confirmed, you can now try to login";
            return Page();
        }

        return Page();
    }
}
