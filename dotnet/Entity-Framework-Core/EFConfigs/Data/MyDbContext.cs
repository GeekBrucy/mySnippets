using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;

namespace EFConfigs.Data;

public class MyDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }
  public DbSet<Person> Persons { get; set; }
  public DbSet<Rabbit> Rabbits { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseMySQL("Server=localhost;Database=EFCoreTute;Uid=root;Pwd=root;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly); // load all IEntityTypeConfiguration
  }
}
