using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_fluent_validation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace _02_fluent_validation.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoController : ControllerBase
{
  [HttpPost]
  public ActionResult AddNewUser(AddNewUserRequest newUser)
  {
    return Ok();
  }
}
