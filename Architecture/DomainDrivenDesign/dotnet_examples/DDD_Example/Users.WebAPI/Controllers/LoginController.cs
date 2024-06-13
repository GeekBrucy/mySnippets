using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.Domain.Enums;
using Users.Domain.Services;
using Users.Infrastructure.Data;
using Users.WebAPI.Attributes;
using Users.WebAPI.Dtos;

namespace Users.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class LoginController : ControllerBase
{
  private readonly UserDomainService _userDomainService;

  public LoginController(UserDomainService userDomainService)
  {
    _userDomainService = userDomainService;
  }

  [HttpPost]
  [UnitOfWork(typeof(UserDbContext))]
  public async Task<IActionResult> LoginByPhoneAndPwd(LoginByPhoneAndPwdRequest req)
  {
    if (req.Password.Length <= 3)
    {
      return BadRequest("Password must be longer than 3");
    }
    var result = await _userDomainService.CheckPassword(req.PhoneNumber, req.Password);

    switch (result)
    {
      case UserAccessResult.OK:
        return Ok("login successfully");
      case UserAccessResult.PasswordError:
      case UserAccessResult.NoPassword:
      case UserAccessResult.PhoneNumberNotFound:
        return BadRequest("login fail");
      case UserAccessResult.Lockout:
        return BadRequest("account is locked");
      default:
        throw new ApplicationException($"Unkown value: {result}");
    }
  }
}
