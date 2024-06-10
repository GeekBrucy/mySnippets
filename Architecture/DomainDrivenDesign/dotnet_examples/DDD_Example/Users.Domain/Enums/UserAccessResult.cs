using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Domain.Enums;

public enum UserAccessResult
{
  OK,
  PhoneNumberNotFound,
  Lockout,
  NoPassword,
  PasswordError
}
