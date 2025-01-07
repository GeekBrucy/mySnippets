using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_v05_webapp_security.Contants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _01_v05_webapp_security.Pages.Account;

public class Logout : PageModel
{
    private readonly ILogger<Logout> _logger;

    public Logout(ILogger<Logout> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await HttpContext.SignOutAsync(CookieSchemeNames.TestCookieAuth);

        return RedirectToPage("/Index");
    }
}
