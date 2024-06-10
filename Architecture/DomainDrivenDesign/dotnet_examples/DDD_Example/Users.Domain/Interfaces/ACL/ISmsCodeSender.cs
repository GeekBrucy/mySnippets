using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Domain.ValueObjects;

namespace Users.Domain.Interfaces.ACL;

public interface ISmsCodeSender
{
  Task SendCodeAsync(PhoneNumber phoneNumber, string code);
}
