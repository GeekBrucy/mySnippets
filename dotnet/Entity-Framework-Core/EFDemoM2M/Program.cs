using EFDemoM2M;

internal class Program
{
  private static async Task Main(string[] args)
  {
    using var demo = new Demo();

    // await demo.Create();
    demo.Print();
  }
}