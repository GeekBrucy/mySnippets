using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFConfigs.Data;

public class MyDbContext : DbContext
{
  private static ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
  public DbSet<Book> Books { get; set; }
  public DbSet<Person> Persons { get; set; }
  public DbSet<Rabbit> Rabbits { get; set; }
  public DbSet<Article> Articles { get; set; }
  public DbSet<Comment> Comments { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<UserRequest> UserRequests { get; set; }
  public DbSet<OrgUnit> OrgUnits { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<Delivery> Deliveries { get; set; }
  public DbSet<Student> Students { get; set; }
  public DbSet<Teacher> Teachers { get; set; }
  public DbSet<RareEquipment> RareEquipments { get; set; }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    var serverVersion = new MySqlServerVersion(new Version());
    optionsBuilder.UseMySql("Server=localhost;Database=EFCoreTute;Uid=root;Pwd=root;", serverVersion);
    // optionsBuilder.UseLoggerFactory(_loggerFactory);
    // optionsBuilder.LogTo(msg =>
    // {
    //   Console.WriteLine(msg);
    // });
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly); // load all IEntityTypeConfiguration
  }
}
