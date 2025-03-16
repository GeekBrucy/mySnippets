using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OAuthServer.Constants;

namespace OAuthServer.Controllers
{
    public class Login : Controller
    {
        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = HttpUtility.UrlEncode(returnUrl);
            return View();
        }

        [HttpPost]
        public async Task<IResult> IndexAsync(string returnUrl)
        {
            await HttpContext.SignInAsync
            (
                AuthConstants.CookieScheme,
                new ClaimsPrincipal
                (
                    new ClaimsIdentity
                    (
                        [
                            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                        ],
                        AuthConstants.CookieScheme
                    )
                )
            );
            return Results.Redirect(returnUrl);
        }
    }
}