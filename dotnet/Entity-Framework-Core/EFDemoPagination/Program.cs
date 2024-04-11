using EFDemoOneToOne;

internal class Program
{
  private static void Main(string[] args)
  {
    using var demo = new Demo();

    demo.Pagination(2, 2);
  }
}