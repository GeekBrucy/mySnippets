using EFConfigs.Data;
using EFConfigs.Models;

internal class Program
{
  private static async Task Main(string[] args)
  {
    using MyDbContext ctx = new MyDbContext();

    Person p = new Person
    {
      Age = 18,
      Name = "Test",
      BirthPlace = "Somewhere",
      Salary = 13
    };

    ctx.Persons.Add(p);
    await ctx.SaveChangesAsync();
    Console.WriteLine("Saved");
  }
}