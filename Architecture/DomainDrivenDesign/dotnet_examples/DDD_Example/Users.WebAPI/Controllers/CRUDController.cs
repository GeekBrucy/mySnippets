using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.Domain.Entities;
using Users.Domain.Interfaces.Repository;
using Users.Infrastructure.Data;
using Users.WebAPI.Attributes;
using Users.WebAPI.Dtos;

namespace Users.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CRUDController : ControllerBase
{
  private readonly IUserRepository _userRepo;
  private readonly UserDbContext _dbContext;

  public CRUDController(IUserRepository userRepository, UserDbContext userDbContext)
  {
    _userRepo = userRepository;
    _dbContext = userDbContext;
  }

  [HttpPost]
  [UnitOfWork(typeof(UserDbContext))]
  public async Task<IActionResult> AddUser(AddUserRequest req)
  {
    if (await _userRepo.FindOneAsync(req.PhoneNumber) != null)
    {
      return BadRequest("phone number exists");
    }
    var user = new User(req.PhoneNumber);
    user.ChangePassword(req.password);
    _dbContext.Users.Add(user);
    return Ok("Done");
  }
}
