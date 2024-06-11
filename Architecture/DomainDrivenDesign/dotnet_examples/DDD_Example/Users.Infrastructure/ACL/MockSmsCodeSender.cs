using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Domain.Interfaces.ACL;
using Users.Domain.ValueObjects;

namespace Users.Infrastructure.ACL;

public class MockSmsCodeSender : ISmsCodeSender
{
  public Task SendCodeAsync(PhoneNumber phoneNumber, string code)
  {
    Console.WriteLine($"Sending code {code} to {phoneNumber.RegionCode} {phoneNumber.Number}");
    return Task.CompletedTask;
  }
}
