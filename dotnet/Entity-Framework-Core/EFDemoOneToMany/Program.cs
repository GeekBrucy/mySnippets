
using EFDemoOneToMany;

internal class Program
{
  private static async Task Main(string[] args)
  {
    // await Demo.BasicInsert();
    // Demo.DemoFetchParent();
    // Demo.DemoFetchChildWithParent();
    Demo.DemoFetchForeignKey();
  }
}