using EFConfigs.Interfaces;
using EFDemoCheckState;

internal class Program
{
  private static void Main(string[] args)
  {
    IDemo demo = new Demo();
    demo.Run();
  }
}