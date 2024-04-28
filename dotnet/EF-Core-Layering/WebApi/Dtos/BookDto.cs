using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos;

public record BookDto
{
  public string Name { get; set; }
  public string AuthorName { get; set; }
  public double Price { get; set; }
  public DateTime PubDate { get; set; }
}
