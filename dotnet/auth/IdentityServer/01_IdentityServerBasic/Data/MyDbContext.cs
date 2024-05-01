using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _01_IdentityServerBasic.Data;

public class MyDbContext : IdentityDbContext
{
  public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
  {
  }
}
