using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFConfigs.Models;

public class Article
{
  public long Id { get; set; }
  public string Title { get; set; }
  public string Content { get; set; }
  public List<Comment> Comments = new List<Comment>();
}
