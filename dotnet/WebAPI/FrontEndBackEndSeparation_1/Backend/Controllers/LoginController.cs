using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
  [HttpPost]
  public LoginResponse Login(LoginRequest loginRequest)
  {
    if (loginRequest.Username == "admin" && loginRequest.Password == "123456")
    {
      var items = Process.GetProcesses().Select(p => new ProcessInfo(p.Id, p.ProcessName, p.WorkingSet64));
      return new LoginResponse(true, items.ToArray());
    }
    return new LoginResponse(false, null);
  }
}
