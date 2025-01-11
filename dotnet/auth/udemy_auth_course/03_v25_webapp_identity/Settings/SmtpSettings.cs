using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_v25_webapp_identity.Settings;

public class SmtpSettings
{
  public string Host { get; set; } = string.Empty;
  public string User { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public string Sender { get; set; } = string.Empty;
  public int Port { get; set; }
}
