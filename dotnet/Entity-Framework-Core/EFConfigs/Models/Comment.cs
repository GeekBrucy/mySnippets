using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFConfigs.Models;

public class Comment
{
  public long Id { get; set; }
  public string Content { get; set; }
  public Article Article { get; set; }
  public long ArticleId { get; set; }

  public override string ToString()
  {
    return $"Id={Id}, Content={Content}, Article=(Id={Article.Id}, Title={Article.Title}, Content={Article.Content})";
  }
}
