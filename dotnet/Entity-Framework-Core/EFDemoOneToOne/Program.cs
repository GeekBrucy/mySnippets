using EFDemoOneToOne;

internal class Program
{
  private static async Task Main(string[] args)
  {
    var demo = new Demo();

    await demo.Create();
  }
}