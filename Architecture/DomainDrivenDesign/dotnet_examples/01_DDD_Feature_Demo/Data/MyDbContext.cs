using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_DDD_Feature_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_DDD_Feature_Demo.Data;

public class MyDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<Shop> Shops { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Blog> Blogs { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseNpgsql("User ID=postgres;Password=postgrespw;Host=localhost;Port=5432;Database=RichDomainModel;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
  }
}
