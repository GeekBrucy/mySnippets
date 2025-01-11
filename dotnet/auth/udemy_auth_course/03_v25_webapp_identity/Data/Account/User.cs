using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace _03_v25_webapp_identity.Data.Account;

public class User : IdentityUser
{
  public string Department { get; set; } = string.Empty;
  public string Position { get; set; } = string.Empty;
}
