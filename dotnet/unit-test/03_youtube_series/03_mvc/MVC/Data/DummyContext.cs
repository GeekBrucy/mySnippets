using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Data;

public class DummyContext
{
  public ICollection<Race> Races { get; set; }
  public ICollection<Club> Clubs { get; set; }
  public ICollection<Address> Addresses { get; set; }
  public ICollection<State> States { get; set; }
  public ICollection<City> Cities { get; set; }
}
