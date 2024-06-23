using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC.Models;

public class AppUser : IdentityUser
{
  public int? Pace { get; set; }
  public int? Mileage { get; set; }
  public string? ProfileImageUrl { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  [ForeignKey("Address")]
  public int? AddressId { get; set; }
  public Address? Address { get; set; }
  public ICollection<Club> Clubs { get; set; }
  public ICollection<Race> Races { get; set; }
}
