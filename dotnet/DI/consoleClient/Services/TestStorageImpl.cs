using consoleClient.Interfaces;

namespace consoleClient.Services;

public class TestStorageImpl : IStorage
{
  private readonly IConfig _config;
  public TestStorageImpl(IConfig config)
  {
    _config = config;
  }
  public void Save(string content, string name)
  {
    string server = _config.GetValue("Server");
    Console.WriteLine($"Saving {content} to {server}/{name}");
  }
}
