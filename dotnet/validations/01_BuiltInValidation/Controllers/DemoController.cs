using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_BuiltInValidation.Dtos;
using _01_BuiltInValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_BuiltInValidation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoController : ControllerBase
{
  [HttpPost]
  public async Task<ActionResult> AddNew(AddNewUserRequest request)
  {
    User user = new User
    {
      Username = request.Username,
      Email = request.Email,
      Password = request.Password
    };

    return Ok();
  }
}
