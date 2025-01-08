using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using _02_v16_webapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace _02_v16_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
  private readonly IConfiguration _configuration;

  public AuthController(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  [HttpPost]
  public IActionResult Authenticate([FromBody] Credential credential)
  {
    if (credential.UserName == "admin" && credential.Password == "password")
    {
      // Creating the security context
      var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "admin"),
            new Claim(ClaimTypes.Email, "admin@test.com"),
            new Claim("Department", "HR"),
            new Claim("Admin", "true"),
            new Claim("Manager", "true"),
            new Claim("EmploymentDate", "2024-01-07"),
        };

      var expiresAt = DateTime.UtcNow.AddMinutes(10);

      return Ok(new
      {
        access_token = CreateToken(claims, expiresAt),
        expires_at = expiresAt
      });
    }

    ModelState.AddModelError("Unauthorized", "You are not authorized to access the endpoint.");

    return Unauthorized(ModelState);
  }

  private string CreateToken(IEnumerable<Claim> claims, DateTime expireAt)
  {
    var secretKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey") ?? "");
    // generate the JWT
    var jwt = new JwtSecurityToken
    (
      claims: claims,
      notBefore: DateTime.UtcNow,
      expires: expireAt,
      signingCredentials: new SigningCredentials
      (
        new SymmetricSecurityKey(secretKey),
        SecurityAlgorithms.HmacSha256Signature
      )
    );
    return new JwtSecurityTokenHandler().WriteToken(jwt);

  }
}
