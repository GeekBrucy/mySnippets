using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Domain.Entities;
using Users.Domain.Enums;
using Users.Domain.Interfaces.ACL;
using Users.Domain.Interfaces.Repository;
using Users.Domain.ValueObjects;

namespace Users.Domain.Services;

public class UserDomainService
{
  private readonly IUserRepository _userRepository;
  private readonly ISmsCodeSender _smsCodeSender;

  public UserDomainService(IUserRepository userRepository, ISmsCodeSender smsCodeSender)
  {
    _userRepository = userRepository;
    _smsCodeSender = smsCodeSender;
  }

  public void ResetAccessFail(User user)
  {
    user.AccessFail.Reset();
  }

  public bool IsLockOut(User user)
  {
    return user.AccessFail.IsLockOut();
  }

  public void AccessFail(User user)
  {
    user.AccessFail.Fail();
  }

  public async Task<UserAccessResult> CheckPassword(PhoneNumber phoneNumber, string password)
  {
    UserAccessResult result = UserAccessResult.OK;
    var user = await _userRepository.FindOneAsync(phoneNumber);
    if (user == null)
    {
      result = UserAccessResult.PhoneNumberNotFound;
    }
    else if (IsLockOut(user) == true)
    {
      result = UserAccessResult.Lockout;
    }
    else if (user.HasPassword() == false)
    {
      result = UserAccessResult.NoPassword;
    }
    else if (user.CheckPassword(password) == false)
    {
      result = UserAccessResult.PasswordError;
    }
    else
    {
      result = UserAccessResult.OK;
    }

    if (user != null)
    {
      if (result == UserAccessResult.OK)
      {
        ResetAccessFail(user);
      }
      else
      {
        AccessFail(user);
      }
    }

    await _userRepository.PublishEventAsync(new UserAccessResultEvent(phoneNumber, result));

    return result;
  }

  public async Task<CheckCodeResult> CheckPhoneCodeAsync(PhoneNumber phoneNumber, string code)
  {
    User? user = await _userRepository.FindOneAsync(phoneNumber);
    if (user == null)
    {
      return CheckCodeResult.PhoneNumberNotFound;
    }
    else if (IsLockOut(user))
    {
      return CheckCodeResult.Lockout;
    }

    string? codeInServer = await _userRepository.FindPhoneNumberCodeAsync(phoneNumber);
    if (codeInServer == null)
    {
      AccessFail(user);
      return CheckCodeResult.CodeError;
    }
    if (code == codeInServer)
    {
      return CheckCodeResult.Ok;
    }
    else
    {
      AccessFail(user);
      return CheckCodeResult.CodeError;
    }

  }
}
