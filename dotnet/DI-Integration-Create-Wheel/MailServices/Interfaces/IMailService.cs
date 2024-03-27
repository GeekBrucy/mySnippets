using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailServices.Interfaces;

public interface IMailService
{
  public void Send(string title, string to, string body);
}
