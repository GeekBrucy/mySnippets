using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Data;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemoOneToOne;

public class Demo : IDisposable
{
  private readonly MyDbContext _ctx;

  public Demo()
  {
    _ctx = new MyDbContext();
  }

  public void Dispose()
  {
    _ctx.Dispose();
  }

  public void Pagination(int pageIndex, int pageSize)
  {
    pageIndex = pageIndex <= 0 ? 1 : pageIndex;
    IQueryable<Article> articles = _ctx.Articles.Include(a => a.Comments).Where(a => a.Id > 0);
    var items = articles.Skip((pageIndex - 1) * pageSize).Take(pageSize);
    foreach (var item in items)
    {
      Console.WriteLine(item);
    }
    long count = articles.LongCount();
    long pageCount = (long)Math.Ceiling(count * 1.0 / pageSize);
    Console.WriteLine($"pageCount={pageCount}");
  }
}
