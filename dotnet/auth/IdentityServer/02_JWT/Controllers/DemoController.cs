using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace _02_JWT.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoController : ControllerBase
{
  // key should only ever exist on the server, never ever pass it to the client, this can be included in the env var (appsettings.json on the server)
  private readonly string jwtKey = "qwertyuiopasdfghjklzxcvbnm123456";

  private readonly string compromisedKey = "123456qwertyuiopasdfghjklzxcvbnm";

  [HttpGet]
  public string GetJwt()
  {
    List<Claim> claims = new List<Claim>
    {
        new Claim("Passport", "123456"),
        new Claim("RandomStuff", "blahblahblah"),
        new Claim("Id", "666"),
        new Claim(ClaimTypes.NameIdentifier, "111"),
        new Claim(ClaimTypes.HomePhone, "12345678910"),
        new Claim(ClaimTypes.Role, "admin"),
        new Claim(ClaimTypes.Role, "user"),
        new Claim(ClaimTypes.Role, "manager"),
    };

    // the following are standard operations
    DateTime expire = DateTime.Now.AddHours(1);
    byte[] secBytes = Encoding.UTF8.GetBytes(jwtKey);
    var secKey = new SymmetricSecurityKey(secBytes);
    var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
    var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expire, signingCredentials: credentials);
    return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
  }
  [HttpGet]
  public string GetJwtWithCompromisedKey()
  {
    List<Claim> claims = new List<Claim>
    {
        new Claim("Passport", "123456"),
        new Claim("RandomStuff", "blahblahblah"),
        new Claim("Id", "666"),
        new Claim(ClaimTypes.NameIdentifier, "111"),
        new Claim(ClaimTypes.HomePhone, "12345678910"),
        new Claim(ClaimTypes.Role, "admin"),
        new Claim(ClaimTypes.Role, "user"),
        new Claim(ClaimTypes.Role, "manager"),
    };

    // the following are standard operations
    DateTime expire = DateTime.Now.AddHours(1);
    byte[] secBytes = Encoding.UTF8.GetBytes(compromisedKey);
    var secKey = new SymmetricSecurityKey(secBytes);
    var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
    var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expire, signingCredentials: credentials);
    return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
  }

  [HttpGet]
  public string[] DecodeJwt(string token)
  {
    string[] jwtStrs = token.Split('.');
    for (int i = 0; i < jwtStrs.Length; i++)
    {
      jwtStrs[i] = jwtStrs[i].Replace('-', '+').Replace('_', '/');
      switch (jwtStrs[i].Length % 4)
      {
        case 2:
          jwtStrs[i] += "==";
          break;
        case 3:
          jwtStrs[i] += "=";
          break;
      }

      var bytes = Convert.FromBase64String(jwtStrs[i]);
      jwtStrs[i] = Encoding.UTF8.GetString(bytes);
    }

    return jwtStrs;
  }

  [HttpGet]
  public void UseJwtSecurityTokenHandler(string jwt)
  {
    JwtSecurityTokenHandler tokenHandler = new();
    TokenValidationParameters validationParameters = new();
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
    validationParameters.IssuerSigningKey = securityKey;
    validationParameters.ValidateIssuer = false;
    validationParameters.ValidateAudience = false;
    // if the compromised jwt is passed in, the ValidateToken will throw exception
    ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwt, validationParameters, out SecurityToken securityToken);

    foreach (var claim in claimsPrincipal.Claims)
    {
      Console.WriteLine($"{claim.Type} = {claim.Value}");
    }
  }
}
