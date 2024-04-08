using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Data;
using EFConfigs.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemoSelfRef;

public class Demo
{
  public async Task InsertAsync()
  {
    using var ctx = new MyDbContext();
    var orgRoot = new OrgUnit { Name = "Root" };
    var orgChild1 = new OrgUnit { Name = "Child 1" };
    var orgChild2 = new OrgUnit { Name = "Child 2" };
    var orgChild3 = new OrgUnit { Name = "Child 3" };
    var orgGrandChild1 = new OrgUnit { Name = "Grand Child 1" };

    // Either bind parent to children parent field, or insert children to parent
    /*
    * NOTE: binding parent to children, it also requires adding children to parent or adding children to db context
    */
    orgRoot.Children.AddRange(new List<OrgUnit> { orgChild1, orgChild2, orgChild3 });
    orgChild1.Children.Add(orgGrandChild1);
    ctx.OrgUnits.Add(orgRoot);
    await ctx.SaveChangesAsync();

  }

  public void PrintHierarchy(OrgUnit parent, MyDbContext ctx, int indentLevel = 0)
  {
    var children = ctx.OrgUnits.Where(o => o.Parent == parent).ToList(); // ToList is required for Pomelo Mysql, otherwise, if there is another query, it will complaint MySqlConnection is already in use
    foreach (var child in children)
    {
      Console.WriteLine(new string('\t', indentLevel) + child);
      PrintHierarchy(child, ctx, indentLevel + 1);
    }
  }

  public void Clear(MyDbContext ctx)
  {
    ctx.Database.ExecuteSqlRaw("truncate table orgunits");
  }
}
