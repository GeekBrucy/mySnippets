using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_with_mapper_lib.Models.DBModels;

public class Library
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Location { get; set; }
  public bool IsDeleted { get; set; }
  public ICollection<Book> Books { get; set; } = new List<Book>();
}
