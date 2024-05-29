using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Basic.Helpers;
using _01_Basic.Models;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _01_Basic.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoSearchController : ControllerBase
{
  private readonly SearchIndexClient _searchIndexClient;
  private readonly SearchClient _searchClient;
  public DemoSearchController(IOptionsSnapshot<AzureSearch> azureSearchConfig)
  {
    var azSearch = azureSearchConfig.Value;

    _searchIndexClient = new SearchIndexClient(new Uri(azSearch.Endpoint), new AzureKeyCredential(azSearch.Key));
    _searchClient = _searchIndexClient.GetSearchClient(azSearch.IndexName);
  }

  [HttpPost]
  public ActionResult Query(string id)
  {
    SearchOptions options;
    SearchResults<FlagSearch> results;


    options = new SearchOptions();
    options.Select.Add("id");

    results = _searchClient.Search<FlagSearch>(id, options);
    return new OkObjectResult(results.GetResults());
  }

  [HttpPost]
  public ActionResult SeedIndex()
  {
    IndexDocumentsBatch<FlagSearch> batch = IndexDocumentsBatch.Create
    (
      SeedAzSearchIndexData.FlagSearchDocumentGenerator(10).ToArray()
    );

    try
    {
      IndexDocumentsResult result = _searchClient.IndexDocuments(batch);
    }
    catch (Exception e)
    {
      return BadRequest(e);
    }

    return Ok();
  }
}
