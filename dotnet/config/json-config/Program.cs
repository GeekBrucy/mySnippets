using Microsoft.Extensions.Configuration;

internal class Program
{
  private static void Main(string[] args)
  {
    ConfigurationBuilder configBuilder = new ConfigurationBuilder();
    configBuilder.AddJsonFile
    (
      "config.json",
      optional: true,
      reloadOnChange: true
    );
    IConfigurationRoot configRoot = configBuilder.Build();

    Console.WriteLine(configRoot["name"]);
    Console.WriteLine(configRoot["proxy:address"]);
    string address = configRoot.GetSection("proxy:address").Value;
    Console.WriteLine(address);
  }
}