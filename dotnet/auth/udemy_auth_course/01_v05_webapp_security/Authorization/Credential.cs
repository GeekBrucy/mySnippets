using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _01_v05_webapp_security.Authorization;

public class Credential
{
  [Required]
  [Display(Name = "User Name")]
  public string UserName { get; set; } = string.Empty;
  [Required]
  [DataType(DataType.Password)]
  public string Password { get; set; } = string.Empty;

  [Display(Name = "Remember Me")]
  public bool RememberMe { get; set; }
}
