using System;
using System.Collections.Generic;
using System.Data.Common;
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
    // await DemoRawQueryWithEntity();
    // await DemoAdoNet();
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

  private async Task DemoRawQueryWithEntity()
  {
    IQueryable<Article> articles = _ctx.Articles.FromSqlInterpolated(@$"select * from articles order by rand() limit 10");
    await foreach (var a in articles.AsAsyncEnumerable())
    {
      Console.WriteLine(a);
    }
  }

  private async Task DemoAdoNet()
  {
    DbConnection conn = _ctx.Database.GetDbConnection();
    if (conn.State != System.Data.ConnectionState.Open)
    {
      await conn.OpenAsync();
    }

    using var cmd = conn.CreateCommand();
    cmd.CommandText = "select * from articles order by rand() limit 10";
    using var reader = cmd.ExecuteReader();
    while (await reader.ReadAsync())
    {
      long id = reader.GetInt64(0);
      string title = reader.GetString(1);
      string content = reader.GetString(2);
      Console.WriteLine($"id={id}, title={title}, content={content}");
    }
  }
}
