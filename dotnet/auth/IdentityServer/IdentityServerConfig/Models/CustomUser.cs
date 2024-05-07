using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerConfig.Models;

public class CustomUser : IdentityUser<long>
{
  /*
    this field is used to handle revoke jwt. If the user login on 2 devices, the later login need to invalid the earlier login 

    or if the user is deleted, and they still use the old jwt to send request, that request needs to be rejected
  */
  public long JwtVersion { get; set; }
}
