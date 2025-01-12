using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _03_v25_webapp_identity.ViewModels;

public class SetupMFAViewModel
{
  public string? Key { get; set; }
  [Required]
  [Display(Name = "Code")]
  public string SecurityCode { get; set; }
  public Byte[]? QRCodeBytes { get; set; }
}
