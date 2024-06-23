using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.ViewModels;

public class ListClubByStateViewModel
{
  public IEnumerable<Club> Clubs { get; set; }
  public bool NoClubWarning { get; set; } = false;
  public string State { get; set; }
}