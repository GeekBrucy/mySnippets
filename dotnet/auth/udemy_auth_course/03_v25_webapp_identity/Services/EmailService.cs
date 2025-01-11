using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using _03_v25_webapp_identity.Settings;
using Microsoft.Extensions.Options;

namespace _03_v25_webapp_identity.Services;

public class EmailService : IEmailService
{
  private readonly SmtpSettings _smtpSettings;

  public EmailService(IOptions<SmtpSettings> options)
  {
    _smtpSettings = options.Value;
  }
  public async Task SendAsync(string from, string to, string subject, string body)
  {
    var message = new MailMessage
    (
      from,
      to,
      subject,
      body
    );

    using (var emailClient = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
    {
      emailClient.Credentials = new NetworkCredential
      (
        _smtpSettings.User,
        _smtpSettings.Password
      );

      await emailClient.SendMailAsync(message);
    }
  }
}
