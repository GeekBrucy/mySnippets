using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _03_v25_webapp_identity.Data.Account;
using _03_v25_webapp_identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _03_v25_webapp_identity.Pages.Account;

public class UserProfile : PageModel
{
    private readonly ILogger<UserProfile> _logger;
    private readonly UserManager<User> _userManager;

    [BindProperty]
    public UserProfileViewModel UserProfileViewModel { get; set; } = new UserProfileViewModel();

    [BindProperty]
    public string? SuccessMessage { get; set; }

    public UserProfile(ILogger<UserProfile> logger, UserManager<User> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        SuccessMessage = string.Empty;

        var (user, departmentClaim, positionClaim) = await GetUserInfoAsync();
        if (user != null)
        {
            UserProfileViewModel.Email = user.Email ?? string.Empty;
            UserProfileViewModel.Department = departmentClaim?.Value ?? string.Empty;
            UserProfileViewModel.Position = positionClaim?.Value ?? string.Empty;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        try
        {
            var (user, departmentClaim, positionClaim) = await GetUserInfoAsync();
            if (user != null && departmentClaim != null)
            {
                await _userManager.ReplaceClaimAsync
                (
                    user, departmentClaim,
                    new Claim(departmentClaim.Type, UserProfileViewModel.Department)
                );
            }

            if (user != null && positionClaim != null)
            {
                await _userManager.ReplaceClaimAsync
                (
                    user, positionClaim,
                    new Claim(positionClaim.Type, UserProfileViewModel.Position)
                );
            }
        }
        catch
        {

            ModelState.AddModelError("UserProfile", "Error occurred during updating user profile");
        }

        SuccessMessage = "The user Profile is updated successfully";

        return Page();
    }

    private async Task<(User? user, Claim? departmentClaim, Claim? positionClaim)> GetUserInfoAsync()
    {
        var user = await _userManager.FindByNameAsync(User.Identity?.Name ?? string.Empty);
        if (user != null)
        {
            var claims = await _userManager.GetClaimsAsync(user);

            var departmentClaim = claims.FirstOrDefault(x => x.Type == "Department");
            var positionClaim = claims.FirstOrDefault(x => x.Type == "Position");

            return (user, departmentClaim, positionClaim);
        }

        return (null, null, null);
    }
}
