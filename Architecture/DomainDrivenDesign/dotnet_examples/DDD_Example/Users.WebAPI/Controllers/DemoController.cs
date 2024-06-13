using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.Infrastructure.Data;
using Users.WebAPI.Attributes;

namespace Users.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoController : ControllerBase
{
  private readonly UserDbContext _userDbContext;
  public DemoController(UserDbContext userDbContext)
  {
    _userDbContext = userDbContext;
  }

  [HttpGet]
  [UnitOfWork(typeof(UserDbContext))]
  public ActionResult Test()
  {

    return Ok();
  }
}
