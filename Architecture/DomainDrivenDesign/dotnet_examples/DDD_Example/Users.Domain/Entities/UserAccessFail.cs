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
  private bool lockOut;
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
    lockOut = false;
    LockoutEnd = null;
    AccessFailedCount = 0;
  }

  public void Fail()
  {
    AccessFailedCount++;

    if (AccessFailedCount >= 3)
    {
      lockOut = true;
      LockoutEnd = DateTime.Now.AddMinutes(5);
    }
  }

  public bool IsLockOut()
  {
    if (!lockOut) return false;

    if (LockoutEnd >= DateTime.Now)
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