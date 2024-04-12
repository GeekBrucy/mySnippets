using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models;
using EFConfigs.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFDemoRawSQL;

public class Demo : BaseDemo
{
  public override async Task RunAsync()
  {
    // await DemoInsert();
    await DemoRawlQueryWithEntity();
  }
  private async Task DemoInsert()
  {
    // ExecuteSqlInterpolatedAsync require FormattableString, the "$" sign is needed
    // FormattableString can prevent SQL injection
    // DO NOT use ExecuteSqlRaw because it can be SQL injected
    const string testInjection = "10; delete from articles";
    FormattableString sql = @$"
      insert into articles(title, content)
      select title, content from articles
      limit {testInjection}
    ";

    Console.WriteLine(sql.Format);
    Console.WriteLine(string.Join(", ", sql.GetArguments()));
    await _ctx.Database.ExecuteSqlInterpolatedAsync(sql);
  }

  private async Task DemoRawlQueryWithEntity()
  {
    IQueryable<Article> articles = _ctx.Articles.FromSqlInterpolated(@$"select * from articles order by rand() limit 10");
    await foreach (var a in articles.AsAsyncEnumerable())
    {
      Console.WriteLine(a);
    }
  }
}
