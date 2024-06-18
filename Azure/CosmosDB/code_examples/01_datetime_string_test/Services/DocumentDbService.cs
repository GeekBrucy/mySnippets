
using Microsoft.Azure.Documents.Client;
using _01_datetime_string_test.Services.Interfaces;
using _01_datetime_string_test.Models;
using Microsoft.Azure.Documents.Linq;

namespace _01_datetime_string_test.Services;

public class DocumentDbService : IDocumentDbService
{
  private readonly DocumentClient _client;
  public DocumentDbService(IConfiguration config)
  {
    _client = new DocumentClient(new Uri(config["Cosmos:Endpoint"]), config["Cosmos:Key"]);
  }

  public async Task<IEnumerable<TestModel>> GetItemsAsync()
  {
    IDocumentQuery<TestModel> query = _client.CreateDocumentQuery<TestModel>(
        UriFactory.CreateDocumentCollectionUri("TestDB", "Generic"),
        new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
        .Where(x => true)
        .AsDocumentQuery();

    List<TestModel> results = new List<TestModel>();
    while (query.HasMoreResults)
    {
      results.AddRange(await query.ExecuteNextAsync<TestModel>());
    }

    return results;
  }
}
