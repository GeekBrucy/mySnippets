using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Data;
using EFConfigs.Models;

namespace EFDemoOneToMany;

public class DemoOneToMany
{
  public static async Task Basic()
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
}
