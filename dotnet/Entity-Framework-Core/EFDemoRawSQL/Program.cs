using EFConfigs.Interfaces;
using EFDemoRawSQL;

internal class Program
{
  private static async Task Main(string[] args)
  {
    using IDemo demo = new Demo();

    await demo.RunAsync();
  }
}