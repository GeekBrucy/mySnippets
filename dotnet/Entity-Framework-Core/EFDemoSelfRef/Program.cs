using EFConfigs.Data;
using EFConfigs.Models;
using EFDemoSelfRef;

internal class Program
{
  private static async Task Main(string[] args)
  {
    var demo = new Demo();

    // await demo.InsertAsync();
    using var ctx = new MyDbContext();
    var parents = ctx.OrgUnits.Where(o => o.Parent == null).ToList();
    Console.WriteLine(ctx.ContextId);
    foreach (var parent in parents)
    {
      Console.WriteLine(parent);
      demo.PrintHierarchy(parent, ctx, 1);
    }
  }
}