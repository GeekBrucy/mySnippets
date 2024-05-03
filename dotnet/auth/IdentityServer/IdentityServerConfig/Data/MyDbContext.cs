using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerConfig.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerConfig.Data;

public class MyDbContext : IdentityDbContext<CustomUser, CustomRole, long>
{
  public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
  {
  }
}
