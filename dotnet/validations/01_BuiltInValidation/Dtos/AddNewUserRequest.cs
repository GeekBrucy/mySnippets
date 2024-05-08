using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _01_BuiltInValidation.Dtos;

public class AddNewUserRequest
{
  [MinLength(3)]
  public string Username { get; set; }
  [Required]
  public string Email { get; set; }
  [Required]
  public string Password { get; set; }
  [Compare(nameof(Password))]
  public string ConfirmPassword { get; set; }
}
