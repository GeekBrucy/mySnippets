using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_with_mapper_lib.Models.PayloadModels;

public class LibraryFE
{
  public int LibraryId { get; set; }         // Maps to Library.Id
  public string LibraryName { get; set; }     // Maps to Library.Name
  public string LibraryLocation { get; set; } // Maps to Library.Location
  public bool IsArchived { get; set; }        // Maps to Library.IsDeleted
  public ICollection<BookFE> BookList { get; set; } = new List<BookFE>();
}
