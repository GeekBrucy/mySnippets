using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aws_and_custom_auth.Pages;

[Authorize]
public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

        Console.WriteLine($"IsAuthenticated: {HttpContext.User?.Identity?.IsAuthenticated}");
        foreach (var claim in HttpContext.User?.Claims)
        {

            Console.WriteLine(claim);
        }
    }
}

