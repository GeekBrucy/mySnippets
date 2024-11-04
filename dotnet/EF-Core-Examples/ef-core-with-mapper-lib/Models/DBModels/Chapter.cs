using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ef_core_with_mapper_lib.Models.DBModels;

public class Chapter
{
  public int Id { get; set; }
  public string Title { get; set; }
  public int Number { get; set; }
  public int BookId { get; set; }
  [JsonIgnore]
  public Book Book { get; set; }
}