using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_SignalR_with_jwt.SignalR;
using IdentityServerConfig.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace _02_SignalR_with_jwt.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoPushMessageOutsideOfHubController : ControllerBase
{
  private readonly UserManager<CustomUser> _userManager;
  private readonly IHubContext<MyHub> _hubContext;
  public DemoPushMessageOutsideOfHubController(IHubContext<MyHub> hubContext, UserManager<CustomUser> userManager)
  {
    _hubContext = hubContext;
    _userManager = userManager;
  }

  [HttpPost]
  public async Task<ActionResult> AddUser(string userName, string password)
  {
    CustomUser newUser = new CustomUser { UserName = userName };
    await _userManager.CreateAsync(newUser, password);
    await _hubContext.Clients.All.SendAsync("PublicMsgReceived", $"Welcome {userName}!!!");

    return Ok();
  }
}
