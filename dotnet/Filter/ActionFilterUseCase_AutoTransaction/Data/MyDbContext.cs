using ActionFilterUseCase_AutoTransaction.Models;
using Microsoft.EntityFrameworkCore;

namespace ActionFilterUseCase_AutoTransaction.Data;

public class MyDbContext : DbContext
{
  public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
  {
  }
  public DbSet<Book> Books { get; set; }
  public DbSet<Person> Persons { get; set; }
}
