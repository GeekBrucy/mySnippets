using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Data;
using EFConfigs.Models;
using EFConfigs.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EFDemoOneToMany;

public class Demo
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

  public static void DemoFetchForeignKey()
  {
    using MyDbContext ctx = new MyDbContext();
    var comment = ctx.Comments.Select(c => new { Id = c.Id, Content = c.Content, ArticleId = c.ArticleId }).First(c => c.Id == 1);
    Console.WriteLine($"Id = {comment.Id}, Content = {comment.Content}, ArticleId = {comment.ArticleId}");
  }

  public static void DemoQuerySingleDirectionRef()
  {
    using MyDbContext ctx = new MyDbContext();

  }

  public static async Task DemoInsertSingleDirectionRef()
  {
    using MyDbContext ctx = new MyDbContext();
    User requester = new User { Name = "Demo Requester" };
    UserRequest request = new UserRequest
    {
      Comments = "Test Leave request",
      Type = UserRequestType.Leave,
      Status = UserRequestStatus.Pending,
      RequestedBy = requester
    };

    ctx.UserRequests.Add(request);
    await ctx.SaveChangesAsync();
  }
}
