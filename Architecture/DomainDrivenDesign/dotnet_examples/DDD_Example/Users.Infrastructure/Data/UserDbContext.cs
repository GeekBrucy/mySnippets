using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;

namespace Users.Infrastructure.Data;

public class UserDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<UserLoginHistory> UserLoginHistories { get; set; }
  public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
  {
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
