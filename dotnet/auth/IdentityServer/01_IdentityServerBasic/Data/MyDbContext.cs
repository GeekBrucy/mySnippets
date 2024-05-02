using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_IdentityServerBasic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace _01_IdentityServerBasic.Data;

public class MyDbContext : IdentityDbContext<CustomUser, CustomRole, long>
{
  public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
  {
  }
  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
  }
}