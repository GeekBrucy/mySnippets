using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Model;

namespace WebAPI.Infrastructure;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) :
      base(dbContextOptions)
  {
  }

  public DbSet<BrainstormSession> BrainstormSessions { get; set; }
}
