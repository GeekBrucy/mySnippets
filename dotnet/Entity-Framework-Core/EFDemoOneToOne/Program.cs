using EFDemoOneToOne;

internal class Program
{
  private static async Task Main(string[] args)
  {
    using var demo = new Demo();

    await demo.Create();
  }
}