using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLib.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityLib.Data;

public class MyDbContext : DbContext
{
  /// <summary>
  /// To work with the callback in Program.cs in WebApi, the constructor is needed
  /// </summary>
  /// <param name="options"></param>
  /// <returns></returns>
  public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
  {
  }

  public DbSet<Book> Books { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
  }
}
