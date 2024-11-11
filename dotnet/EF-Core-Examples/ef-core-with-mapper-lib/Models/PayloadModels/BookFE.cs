using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_with_mapper_lib.Models.PayloadModels;

public class BookFE
{
  public int BookId { get; set; }             // Maps to Book.Id
  public string BookTitle { get; set; }       // Maps to Book.Title
  public string BookAuthor { get; set; }      // Maps to Book.Author
  public bool IsArchived { get; set; } = false;      // Maps to Book.IsDeleted
  public ICollection<ChapterFE> BookChapters { get; set; }
}
