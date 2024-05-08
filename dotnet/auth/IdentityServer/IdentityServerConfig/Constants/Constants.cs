using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerConfig.Models;

namespace IdentityServerConfig.Constants;

public static class DemoProjConstants
{
  public static class Jwt
  {
    public const string JwtVersionClaimKey = nameof(CustomUser.JwtVersion);
  }
}
