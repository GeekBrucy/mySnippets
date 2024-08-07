using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using EFConfigs.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFDemoCheckState;

public class Demo : BaseDemo
{
  public override void Run()
  {
    // PrintStates();
    // NoTracking();
    ModifyState();
  }

  private void NoTracking()
  {
    // if the entity is only used for display, there is no point to store the snapshot of it
    // hence AsNoTracking can be used
    var articles = _ctx.Articles.AsNoTracking().Take(3).ToList();
    foreach (var a in articles)
    {
      Console.WriteLine(a);
      Console.WriteLine(_ctx.Entry(a).State); // Detached
      a.Title = "This hsould not be changed";
    }
    _ctx.SaveChanges();
  }

  /// <summary>
  /// Not recommended to use
  /// </summary>
  private void ModifyState()
  {
    Article a = new Article { Id = 1, Title = "Modify state, title" };
    var articleEntry = _ctx.Entry(a);
    articleEntry.Property(nameof(a.Title)).IsModified = true;
    /*
      // the following state change can delete the article record with id 2    
      Article a2 = new Article { Id = 2 };
      _ctx.Entry(a).State = EntityState.Deleted;
      _ctx.SaveChanges();
    */
    _ctx.SaveChanges();
  }

  private void PrintStates()
  {
    var articles = _ctx.Articles.Take(3).ToList();
    var a1 = articles[0];
    var a2 = articles[1];
    var a3 = articles[2];

    var a4 = new Article { Title = "a4 obj", Content = "test a4 state" };
    var a5 = new Article { Title = "a5 obj", Content = "test a5 state" };
    var a6 = new Article { Title = "a6 obj", Content = "test a6 state" };

    a1.Title = "changed";
    _ctx.Remove(a2);
    _ctx.Add(a4);

    EntityEntry e1 = _ctx.Entry(a1);
    EntityEntry e2 = _ctx.Entry(a2);
    EntityEntry e3 = _ctx.Entry(a3);
    EntityEntry e4 = _ctx.Entry(a4);
    EntityEntry e5 = _ctx.Entry(a5);

    Console.WriteLine($"e1.State: {e1.State}");
    Console.WriteLine($"e1.DebugView.LongView: {e1.DebugView.LongView}");
    Console.WriteLine($"e2.State: {e2.State}");
    Console.WriteLine($"e3.State: {e3.State}");
    Console.WriteLine($"e4.State: {e4.State}");
    Console.WriteLine($"e5.State: {e5.State}");
  }
}
