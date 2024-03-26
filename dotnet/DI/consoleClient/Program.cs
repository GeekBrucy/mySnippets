using consoleClient.Demo;

internal class Program
{
  private static void Main(string[] args)
  {
    // DemoWIthoutDI.RunWithTestServiceImpl();

    // DemoWithDI.RunWithDI();

    // DemoWithDI.RunWithTransient();

    // DemoWithDI.RunWithSingleton();

    // DemoWithDI.RunWithScoped();

    // var testWithInterface = new DemoWithDI_Interface_Oriented();

    // testWithInterface.Run();
    // testWithInterface.RunWithMultipleServices();

    DemoDIInfectious.Run();
  }
}