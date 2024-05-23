using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Basic.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_Basic.Data;

public class MyDbContext : DbContext
{
  public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
  {
  }

  public DbSet<Flag> Flags { get; set; }
}
