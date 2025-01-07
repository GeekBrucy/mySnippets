using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _01_v05_webapp_security.Pages;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Console.WriteLine($"Is Authenticated: {User.Identity.IsAuthenticated}");
        foreach (var claim in ((ClaimsIdentity)User.Identity).Claims)
        {
            Console.WriteLine($"claim: {claim}");
        }
    }
}
