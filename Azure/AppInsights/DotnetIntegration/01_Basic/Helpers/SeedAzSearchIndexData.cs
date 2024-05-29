using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Basic.Models;
using Azure.Search.Documents.Models;

namespace _01_Basic.Helpers;

public class SeedAzSearchIndexData
{
  public static IEnumerable<IndexDocumentsAction<FlagSearch>> FlagSearchDocumentGenerator(int total)
  {
    IEnumerable<IndexDocumentsAction<FlagSearch>> data = Enumerable.Empty<IndexDocumentsAction<FlagSearch>>();

    for (var i = 1; i <= total; i++)
    {
      data = data.Append(
        IndexDocumentsAction.Upload
        (
          new FlagSearch
          {
            Id = i.ToString(),
            Value = $"Test{i}"
          }
        )
      );
    }

    return data;
  }
}
