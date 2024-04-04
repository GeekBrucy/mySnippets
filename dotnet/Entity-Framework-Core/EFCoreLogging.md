[back](README.md)

# EF Core Logging Table of Contents

# Logger factory (log to console)

1. Install package `Microsoft.Extensions.Logging.Console`
2. Config `DbContext`

```c#
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class MyDbContext : DbContext
{
  private static ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
  ...
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    ...
    optionsBuilder.UseLoggerFactory(_loggerFactory);
  }
}
```

# Simple Console Log

```c#
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class MyDbContext : DbContext
{
  private static ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
  ...
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    ...
    optionsBuilder.LogTo(msg =>
    {
      Console.WriteLine(msg);
    });
  }
}
```

# ToQueryString (only woks on query)

Apply at the client side

```c#
using MyDbContext ctx = new MyDbContext();
var books = ctx.Books.GroupBy(b => b.Author)
  .Select(g => new { Name = g.Key, BooksCount = g.Count(), MaxPrice = g.Max(b => b.Price) });
books.ToQueryString();
```
