using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ef_core_with_mapper_lib.Models.DBModels;

public class Book : BaseModel
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  public int LibraryId { get; set; }

  public List<Chapter> Chapters { get; set; } = new List<Chapter>();

  [JsonIgnore]
  public Library Library { get; set; }
}
