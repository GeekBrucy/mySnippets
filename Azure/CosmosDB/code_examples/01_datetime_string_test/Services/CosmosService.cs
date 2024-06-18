
using _01_datetime_string_test.Models;
using _01_datetime_string_test.Services.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace _01_datetime_string_test.Services;

public class CosmosService : ICosmosService
{
  private readonly CosmosClient _client;

  public CosmosService(IConfiguration config)
  {
    var connStr = config.GetConnectionString("Cosmos");
    _client = new CosmosClient(connectionString: connStr);
  }
  private Container container
  {
    get => _client.GetDatabase("TestDB").GetContainer("Generic");
  }

  public async Task<IEnumerable<TestModel>> RetrieveAllTestDatasAsync()
  {
    var queryable = container.GetItemLinqQueryable<TestModel>();
    using FeedIterator<TestModel> feed = queryable.Where(x => true).ToFeedIterator();
    List<TestModel> results = new();
    while (feed.HasMoreResults)
    {
      var response = await feed.ReadNextAsync();
      foreach (TestModel item in response)
      {
        results.Add(item);
      }
    }
    return results;
  }
}
