using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Data;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemoOneToMany;

public class DemoOneToMany
{
  public static async Task BasicInsert()
  {
    using MyDbContext ctx = new MyDbContext();

    Article article = new Article
    {
      Title = "Test title",
      Content = "Test content"
    };

    Comment comment1 = new Comment
    {
      Content = "Test Comment Content 1",
    };

    Comment comment2 = new Comment
    {
      Content = "Test Comment Content 2",
    };

    article.Comments.Add(comment1);
    article.Comments.Add(comment2);
    ctx.Add(article);

    await ctx.SaveChangesAsync();
  }

  public static void DemoFetchParent()
  {
    using MyDbContext ctx = new MyDbContext();
    var article = ctx.Articles.Include(a => a.Comments).First(a => a.Id == 1);

    Console.WriteLine(article);
  }

  public static void DemoFetchChildWithParent()
  {
    using MyDbContext ctx = new MyDbContext();
    var comment = ctx.Comments.Include(c => c.Article).First(c => c.Id == 1);
    Console.WriteLine(comment);
  }
}
