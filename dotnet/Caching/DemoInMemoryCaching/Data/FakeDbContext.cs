using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoResponseCache.Models;

namespace Data
{
  public class FakeDbContext
  {
    private static List<Book> Books = Enumerable
      .Range(0, 100)
      .Select(i => new Book(i, "Test Book " + i))
      .ToList();

    public static Book? GetById(long id)
    {
      return Books.FirstOrDefault(b => b.Id == id);
    }
  }
}