using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace EFDemoConcurrency;

public class Demo : BaseDemo
{
  public override void Run()
  {
    // Problem();
    Pessimistic();
  }

  /// <summary>
  /// To produce the scenario, it will require to open two built application
  /// </summary>
  private void Problem()
  {
    var article = _ctx.Articles.Where(a => a.Id == 1).First();
    Console.WriteLine($"Article id = {article.Id}' thumb up is {article.ThumbUp}");
    Console.ReadLine();
    article.ThumbUp += 1;
    Thread.Sleep(10000); // this is for manual concurrency
    _ctx.SaveChanges();
    Console.WriteLine($"Article id = {article.Id}' thumb up is updated to {article.ThumbUp}");
    Console.ReadLine();
  }
  /// <summary>
  /// EF Core doesn't have pessimistic handle, so the solution is to add lock to the row or table
  /// </summary>
  private void Pessimistic()
  {
    using var transaction = _ctx.Database.BeginTransaction();
    // have to use raw sql to add lock to the target row. Different DB has different lock statement
    Console.WriteLine($"Press enter to update");
    Console.ReadLine();
    Console.WriteLine($"[{DateTime.Now}] Before Locking Article Id 1");
    // if the concurrency happens, it will wait until the previous operation is finished and then continue
    var article = _ctx.Articles.FromSqlInterpolated($"select * from articles where id = 1 for update").First();
    Console.WriteLine($"[{DateTime.Now}] After Locking Article Id 1");
    article.ThumbUp += 1;
    Thread.Sleep(10000); // this is for manual concurrency
    _ctx.SaveChanges(); // this will release the lock,
    Console.WriteLine($"[{DateTime.Now}] Article id = {article.Id}' thumb up is updated to {article.ThumbUp}");
    transaction.Commit();
    Console.ReadLine();
  }
}
