using EFDemoConcurrency;

internal class Program
{
  private static void Main(string[] args)
  {
    using var demo = new Demo();
    demo.Run();
  }
}