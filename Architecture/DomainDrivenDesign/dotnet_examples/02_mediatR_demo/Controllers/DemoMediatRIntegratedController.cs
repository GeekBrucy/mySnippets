using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_mediatR_demo.Data;
using _02_mediatR_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace _02_mediatR_demo.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoMediatRIntegratedController : ControllerBase
{
  private readonly MyDbContext _myDbContext;

  public DemoMediatRIntegratedController(MyDbContext myDbContext)
  {
    _myDbContext = myDbContext;
  }

  [HttpPost]
  public async Task<ActionResult> CreateUser(string username)
  {
    var user = new User(username, "123456");
    _myDbContext.Users.Add(user);
    await _myDbContext.SaveChangesAsync();
    return new OkObjectResult(user);
  }

  [HttpPost]
  public async Task<ActionResult> ChangeUserName(string oldUserName, string newUserName)
  {
    var user = _myDbContext.Users.FirstOrDefault(u => u.UserName == oldUserName);
    if (user == null)
    {
      return NotFound();
    }
    var isNewNameExists = _myDbContext.Users.Any(u => u.UserName == newUserName);
    if (isNewNameExists == true)
    {
      return BadRequest("New Username exists!");
    }
    user.ChangeUserName(newUserName);
    await _myDbContext.SaveChangesAsync();
    return new OkObjectResult(user);
  }
}
