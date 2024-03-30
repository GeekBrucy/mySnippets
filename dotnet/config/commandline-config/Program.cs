using Microsoft.Extensions.Configuration;

internal class Program
{
  private static void Main(string[] args)
  {
    ConfigurationBuilder configBuilder = new ConfigurationBuilder();

    configBuilder.AddCommandLine(args);
    IConfigurationRoot configRoot = configBuilder.Build();
    // when `dotnet run`, just add `age=100`
    // so the full command will be `dotnet run age=100`
    // do similar thing when running the executable file
    var age = configRoot.GetSection("age").Value;
    Console.WriteLine(age);
  }
}