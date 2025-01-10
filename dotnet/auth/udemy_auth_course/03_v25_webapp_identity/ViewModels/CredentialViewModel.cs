using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _03_v25_webapp_identity.ViewModels;

public class CredentialViewModel
{
  [Required]
  public string Email { get; set; } = string.Empty;
  [Required]
  [DataType(DataType.Password)]
  public string Password { get; set; } = string.Empty;

  [Display(Name = "Remember Me")]
  public bool RememberMe { get; set; }
}
