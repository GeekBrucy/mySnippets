using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServerConfig.Helpers;

public class JwtHelper
{
  public static string JwtGenerator(string jwtKey, IEnumerable<Claim> claims)
  {
    DateTime expire = DateTime.Now.AddHours(1);
    byte[] secBytes = Encoding.UTF8.GetBytes(jwtKey);
    var secKey = new SymmetricSecurityKey(secBytes);
    var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
    var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expire, signingCredentials: credentials);
    return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
  }
}
