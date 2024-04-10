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

  public void Query()
  {
    var ret = _ctx.Articles.Include(a => a.Comments).Where(a => a.Comments.Any(c => c.Content.Contains("Content 2"))).ToList();
    foreach (var article in ret)
    {
      Console.WriteLine($"article {article.Id}: title={article.Title}, content={article.Content}, comments total={article.Comments.Count()}");
      foreach (var cmt in article.Comments)
      {
        Console.WriteLine(new string("\t") + $"comment {cmt.Id}: content={cmt.Content}");
      }
    }
  }
}
