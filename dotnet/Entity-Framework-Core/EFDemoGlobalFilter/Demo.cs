using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace EFDemoGlobalFilter;

public class Demo : BaseDemo
{
  public override async Task RunAsync()
  {
    await Query();
  }

  public override void Run()
  {
    QueryWithoutGlobalFilter();
  }
  private void QueryWithoutGlobalFilter()
  {
    var article = _ctx.Articles.IgnoreQueryFilters().Where(a => a.Id == 3).FirstOrDefault();

    Console.WriteLine(article);
  }
  private async Task Query()
  {
    Console.WriteLine("Getting article id = 3");
    var article = _ctx.Articles.Where(a => a.Id == 3).FirstOrDefault();
    if (article == null)
    {
      return;
    }
    Console.WriteLine("Marking article as deleted");
    article.IsDeleted = true;
    Console.WriteLine("Saving changes");
    await _ctx.SaveChangesAsync();

    Console.WriteLine("Querying article id = 3");
    var article2 = _ctx.Articles.Where(a => a.Id == 3).FirstOrDefault();

    Console.WriteLine($"Result: {article2}"); // get null, because the HasQueryFilter in place
  }
}
