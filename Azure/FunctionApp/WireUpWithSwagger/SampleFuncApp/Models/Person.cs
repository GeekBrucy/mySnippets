using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleFuncApp.Models;

public class Person
{
  public int Id { get; set; }
  [Required]
  [MinLength(1)]
  [MaxLength(20)]
  public string FirstName { get; set; }
  public string MiddleName { get; set; }
  [Required]
  [MinLength(1)]
  [MaxLength(20)]
  public string LastName { get; set; }
  [Required]
  public DateTime DOB { get; set; }
  [MinLength(20)]
  [MaxLength(200)]
  public string Bio { get; set; }
}
