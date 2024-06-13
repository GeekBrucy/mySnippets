using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Domain.Interfaces;
using Users.Domain.ValueObjects;

namespace Users.Domain.Entities;

public record UserLoginHistory : IAggregateRoot
{
  public long Id { get; init; }
  public Guid? UserId { get; init; }
  public PhoneNumber PhoneNumber { get; init; }
  public DateTime CreatedDateTime { get; init; }
  public string Message { get; init; }
  private UserLoginHistory() { } // for EF Core use
  public UserLoginHistory(Guid? userId, PhoneNumber phoneNumber, string message)
  {
    UserId = userId;
    PhoneNumber = phoneNumber;
    CreatedDateTime = DateTime.UtcNow;
    Message = message;
  }
}
