using Microsoft.Extensions.Configuration;

internal class Program
{
  private static void Main(string[] args)
  {
    ConfigurationBuilder configBuilder = new ConfigurationBuilder();

    configBuilder.AddEnvironmentVariables();
    IConfigurationRoot configRoot = configBuilder.Build();

    var envVar = configRoot.GetSection("Path").Value;
    Console.WriteLine(envVar);
  }
}