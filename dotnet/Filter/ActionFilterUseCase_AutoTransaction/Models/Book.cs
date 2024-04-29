using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionFilterUseCase_AutoTransaction.Models;

public class Book
{
  public long Id { get; set; }
  public string Name { get; set; }
  public string AuthorName { get; set; }
  public double Price { get; set; }
  public DateTime PubDate { get; set; }
}
