using json_config.Models;
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

    Proxy proxy = configRoot.GetSection("proxy").Get<Proxy>();
    Console.WriteLine($"{proxy.Address}:{proxy.Port}");

    Config config = configRoot.Get<Config>();

    Console.WriteLine("Name={0}, Age={1}, Proxy.Address={2}, Proxy.Port={3}", config.Name, config.Age, config.Proxy.Address, config.Proxy.Port);
  }
}