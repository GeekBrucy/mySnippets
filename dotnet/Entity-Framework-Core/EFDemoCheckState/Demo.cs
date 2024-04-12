using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using EFConfigs.Models.Shared;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFDemoCheckState;

public class Demo : BaseDemo
{
  public override void Run()
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
