using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using EFConfigs.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace EFDemoConcurrency;

public class Demo : BaseDemo
{
  public override void Run()
  {
    // Problem();
    // Pessimistic();
    // OptimisticConcurrencyToken();
    OptimisticRowVersion();
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

  private void OptimisticConcurrencyToken()
  {
    Console.WriteLine("Enter your name to occupy the equipment");
    string name = Console.ReadLine();
    var equipment = _ctx.RareEquipments.Where(r => r.Id == 1).First();
    // clear Owner field before test
    equipment.Owner = null;
    _ctx.SaveChanges();
    if (!string.IsNullOrEmpty(equipment.Owner))
    {
      if (equipment.Owner == name)
      {
        Console.WriteLine($"[{DateTime.Now}] You are the owner of equipment [{equipment.Name}] already.");
      }
      else
      {
        Console.WriteLine($"[{DateTime.Now}] The equipment [{equipment.Name}] belongs to {equipment.Owner}.");
      }
      return;
    }
    equipment.Owner = name;
    Thread.Sleep(5000);
    try
    {
      _ctx.SaveChanges();
      Console.WriteLine($"[{DateTime.Now}] You now own the equipment [{equipment.Name}]!!");
    }
    catch (DbUpdateConcurrencyException ex)
    {
      var entry = ex.Entries.First();

      string newVal = entry.GetDatabaseValues().GetValue<string>(nameof(RareEquipment.Owner)); // GetDatabaseValues has async version, try to use that instead
      Console.WriteLine($"[{DateTime.Now}] The value is updated to [{newVal}], please try again later");
    }

    Console.ReadKey();
  }

  private void OptimisticRowVersion()
  {
    Console.WriteLine("Enter your name to occupy the equipment");
    string name = Console.ReadLine();
    var equipment = _ctx.RareEquipments.Where(r => r.Id == 1).First();
    // clear Owner field before test
    equipment.Owner = null;
    _ctx.SaveChanges();
    if (!string.IsNullOrEmpty(equipment.Owner))
    {
      if (equipment.Owner == name)
      {
        Console.WriteLine($"[{DateTime.Now}] You are the owner of equipment [{equipment.Name}] already.");
      }
      else
      {
        Console.WriteLine($"[{DateTime.Now}] The equipment [{equipment.Name}] belongs to {equipment.Owner}.");
      }
      return;
    }
    equipment.Owner = name;
    Thread.Sleep(5000);
    try
    {
      _ctx.SaveChanges();
      Console.WriteLine($"[{DateTime.Now}] You now own the equipment [{equipment.Name}]!!");
    }
    catch (DbUpdateConcurrencyException ex)
    {
      // var entry = ex.Entries.First();

      // string newVal = entry.GetDatabaseValues().GetValue<string>(nameof(RareEquipment.Owner)); // GetDatabaseValues has async version, try to use that instead
      Console.WriteLine($"[{DateTime.Now}] The value is updated, please try again later");
      // Console.WriteLine($"[{DateTime.Now}] The value is updated to [{newVal}], please try again later");
    }

    Console.ReadKey();
  }
}
