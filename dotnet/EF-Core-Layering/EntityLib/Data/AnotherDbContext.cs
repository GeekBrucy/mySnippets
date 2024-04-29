using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLib.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityLib.Data;

public class AnotherDbContext : DbContext
{
  public AnotherDbContext(DbContextOptions<AnotherDbContext> options) : base(options)
  {
  }

  public DbSet<Person> Persons { get; set; }
}
