using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
using EFConfigs.Models;

namespace EFConfigs.Data;

public class BookFaker : Faker<Book>
{
  public BookFaker()
  {
    RuleFor(d => d.Title, f => f.Commerce.Department());
    RuleFor(d => d.PubTime, f => f.Date.Recent());
    RuleFor(d => d.Price, f => f.Commerce.Price(1, 1000, 2).First());
    RuleFor(d => d.Author, f => f.Name.FullName());
  }
}
