using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_v25_webapp_identity.Services;

public interface IEmailService
{
  Task SendAsync(string from, string to, string subject, string body);
}
