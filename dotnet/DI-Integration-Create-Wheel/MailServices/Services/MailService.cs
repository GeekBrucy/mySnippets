using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigServices.Interfaces;
using LogServices.Interfaces;
using MailServices.Interfaces;

namespace MailServices.Services;

public class MailService : IMailService
{
  private readonly ILogProvider _logProvider;
  private readonly IConfigService _config;

  public MailService(ILogProvider logProvider, IConfigService config)
  {
    _logProvider = logProvider;
    _config = config;
  }
  public void Send(string title, string to, string body)
  {
    _logProvider.LogInfo("Ready to send email");
    string smtpServer = _config.GetValue("SmtpServer");
    string userName = _config.GetValue("UserName");
    string password = _config.GetValue("Password");
    Console.WriteLine($"SmtpServer Details: smtpServer = {smtpServer}, username = {userName}, password = {password}");
    Console.WriteLine($"Sent Email! title = {title}, to = {to}, body = {body}");
    _logProvider.LogInfo("Email Sent");
  }
}
