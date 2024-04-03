using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFConfigs.Models;

public class Book
{
  public long Id { get; set; }
  public string Title { get; set; }
  public DateTime PubTime { get; set; }
  public double Price { get; set; }
  public string Author { get; set; }

  public override string ToString()
  {
    return $"Id={Id}, Title={Title}, PubTime={PubTime}, Price={Price}, Author={Author}";
  }
}
