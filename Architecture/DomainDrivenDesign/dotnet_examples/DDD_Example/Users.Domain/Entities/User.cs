using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Domain.Helpers;
using Users.Domain.Interfaces;
using Users.Domain.ValueObjects;

namespace Users.Domain.Entities;

public record User : IAggregateRoot
{
  public Guid Id { get; init; }
  public PhoneNumber PhoneNumber { get; private set; }
  private string? passwordHash;
  public UserAccessFail AccessFail { get; private set; }
  private User() { } // for EF Core use

  public User(PhoneNumber phoneNumber)
  {
    PhoneNumber = phoneNumber;
    Id = Guid.NewGuid();
    AccessFail = new UserAccessFail(this);
  }

  public bool HasPassword()
  {
    return !string.IsNullOrEmpty(passwordHash);
  }

  public void ChangePassword(string value)
  {
    if (value.Length <= 3)
      throw new ArgumentException("Password length cannot be less than 3");

    passwordHash = HashHelper.ComputeMd5Hash(value);
  }

  public bool CheckPassword(string password)
  {
    return passwordHash == HashHelper.ComputeMd5Hash(password);
  }

  public void ChangePhoneNumber(PhoneNumber phoneNumber)
  {
    PhoneNumber = phoneNumber;
  }
}
