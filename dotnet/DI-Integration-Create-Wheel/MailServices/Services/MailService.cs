using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailServices.Interfaces;

namespace MailServices.Services;

public class MailService : IMailService
{
  public void Send(string title, string to, string body)
  {
    Console.WriteLine($"Sent Email! title = {title}, to = {to}, body = {body}");
  }
}
