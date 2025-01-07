
using System.Security.Claims;
using System.Threading.Tasks;
using _01_v05_webapp_security.Contants;
using _01_v05_webapp_security.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _01_v05_webapp_security.Pages.Account;

public class Login : PageModel
{
    [BindProperty] // with BindProperty attribute, make the property available in the cshtml
    public Credential Credential { get; set; } = new Credential();
    private readonly ILogger<Login> _logger;

    public Login(ILogger<Login> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine($"Is Model State valid: {ModelState.IsValid}");
        Console.WriteLine($"Credential.UserName: {Credential.UserName}");
        Console.WriteLine($"Credential.Password: {Credential.Password}");

        // Verify the credential
        if (Credential.UserName == "admin" && Credential.Password == "password")
        {
            // Creating the security context
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Email, "admin@test.com"),
            };
            var identity = new ClaimsIdentity(claims, CookieSchemeNames.TestCookieAuth);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            // HttpContent.SignInAsync
            // Microsoft.AspNetCore.Authentication
            await HttpContext.SignInAsync(CookieSchemeNames.TestCookieAuth, claimsPrincipal); // generate cookie

            return RedirectToPage("/Index");
        }

        return Page();
    }
}
