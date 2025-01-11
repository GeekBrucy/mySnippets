using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _03_v25_webapp_identity.ViewModels;

public class AuthenticatorMFAViewModel
{
  [Required]
  [Display(Name = "Code")]
  public string SecurityCode { get; set; } = string.Empty;

  public bool RememberMe { get; set; }
}
