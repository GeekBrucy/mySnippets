using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ef_core_with_mapper_lib.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace ef_core_with_mapper_lib.DBContexts;

public class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
  {
  }

  public DbSet<Library> Libraries { get; set; }
  public DbSet<Book> Books { get; set; }
  public DbSet<Chapter> Chapters { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    modelBuilder.Entity<Library>()
        .HasMany(l => l.Books)
        .WithOne(b => b.Library);

    modelBuilder.Entity<Book>()
        .HasMany(b => b.Chapters)
        .WithOne(c => c.Book);
  }
}
