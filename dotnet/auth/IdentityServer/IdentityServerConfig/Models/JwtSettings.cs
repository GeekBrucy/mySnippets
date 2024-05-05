using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerConfig.Models;

public class JwtSettings
{
  public string SecKey { get; set; }
  public int ExpireSeconds { get; set; }
}
