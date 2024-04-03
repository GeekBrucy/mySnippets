using EFConfigs.Data;
using EFConfigs.Models;

internal class Program
{
  private static async Task Main(string[] args)
  {
    using MyDbContext ctx = new MyDbContext();
    // await DemoSave(ctx);
    // DemoQuery(ctx);
    // await DemoUpdate(ctx);
    await DemoDelete(ctx);
  }
  static async Task DemoSave(MyDbContext ctx)
  {
    int bookAmount = 5;
    var books = new BookFaker().Generate(bookAmount);
    ctx.AddRange(books);
    await ctx.SaveChangesAsync();
    Console.WriteLine($"Created {bookAmount} books");
  }

  static void DemoQuery(MyDbContext ctx)
  {
    IQueryable<Book> filteredBooks = ctx.Books.Where(b => b.Price > 40);
    Console.WriteLine($"{filteredBooks.Count()} book(s) Price(s) is/are greater than 40");

    var books = ctx.Books.GroupBy(b => b.Author)
      .Select(g => new { Name = g.Key, BooksCount = g.Count(), MaxPrice = g.Max(b => b.Price) });
    foreach (var book in books)
    {
      Console.WriteLine($"{book.Name}, Total={book.BooksCount}, MaxPrice={book.MaxPrice}");
    }
  }

  static async Task DemoUpdate(MyDbContext ctx)
  {
    var b = ctx.Books.First(b => b.Id == 1);

    b.Title = "Dotnet EF Core Update";
    await ctx.SaveChangesAsync();
    Console.WriteLine("Updated");
  }

  static async Task DemoDelete(MyDbContext ctx)
  {
    var b = ctx.Books.First(b => b.Id == 3);
    ctx.Books.Remove(b);

    await ctx.SaveChangesAsync();

    Console.WriteLine("Deleted");
  }
}