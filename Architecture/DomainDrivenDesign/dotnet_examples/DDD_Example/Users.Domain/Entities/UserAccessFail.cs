using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Domain.Entities;

public record UserAccessFail
{
  public Guid Id { get; init; }
  public Guid UserId { get; init; }
  public User User { get; init; }
  private bool isLockOut;
  public DateTime? LockoutEnd { get; private set; }
  public int AccessFailedCount { get; private set; }
  private UserAccessFail() { } // For EF Core use
  public UserAccessFail(User user)
  {
    Id = Guid.NewGuid();
    User = user;
  }

  public void Reset()
  {
    isLockOut = false;
    LockoutEnd = null;
    AccessFailedCount = 0;
  }

  public void Fail()
  {
    AccessFailedCount++;

    if (AccessFailedCount >= 3)
    {
      isLockOut = true;
      LockoutEnd = DateTime.UtcNow.AddMinutes(5);
    }
  }

  public bool IsLockOut()
  {
    if (!isLockOut) return false;

    if (LockoutEnd >= DateTime.UtcNow)
    {
      return true;
    }
    else
    {
      AccessFailedCount = 0;
      LockoutEnd = null;
      return false;
    }
  }
}