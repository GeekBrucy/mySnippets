using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_with_mapper_lib.Models.DBModels;

public class Book
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  public bool IsDeleted { get; set; }
  public int LibraryId { get; set; }
  public Library Library { get; set; }
}
