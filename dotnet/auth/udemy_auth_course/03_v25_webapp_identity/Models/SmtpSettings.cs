using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_v25_webapp_identity.Models;

public class SmtpSettings
{
  public string SmtpServer { get; set; } = string.Empty;
  public string SmtpUser { get; set; } = string.Empty;
  public string SmtpPassword { get; set; } = string.Empty;
  public string SmtpSender { get; set; } = string.Empty;
}
