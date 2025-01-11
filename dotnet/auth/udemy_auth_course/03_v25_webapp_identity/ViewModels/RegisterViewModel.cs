using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _03_v25_webapp_identity.ViewModels;

public class RegisterViewModel
{
  [Required]
  [EmailAddress(ErrorMessage = "Invalid email address.")]
  public string Email { get; set; } = string.Empty;

  [Required]
  [DataType(dataType: DataType.Password)]
  public string Password { get; set; } = string.Empty;

  [Required]
  public string Department { get; set; } = string.Empty;

  [Required]
  public string Position { get; set; } = string.Empty;

}
