using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLib.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityLib.Data;

public class MyDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
  }
}
