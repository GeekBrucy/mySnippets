using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServerConfig.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace _02_SignalR_with_jwt.SignalR;

[Authorize]
public class MyHub : Hub
{
  private readonly UserManager<CustomUser> _userManager;
  public MyHub(UserManager<CustomUser> userManager)
  {
    _userManager = userManager;
  }
  public Task SendPublicMsg(string msg)
  {
    var claim = Context.User.FindFirst(ClaimTypes.Name);

    string connId = Context.ConnectionId;
    string msgToSend = $"[{DateTime.Now}] {claim?.Value ?? Context.GetHttpContext().Connection.RemoteIpAddress.ToString()}: {msg} ";
    return Clients.All.SendAsync("PublicMsgReceived", msgToSend);
  }

  public async Task SendPrivateMessage(string targetUsername, string message)
  {
    CustomUser? user = await _userManager.FindByNameAsync(targetUsername);
    // if user == null

    long userId = user.Id;
    string currentUsername = Context.UserIdentifier; // user id, 1,2,3,4... etc
    string messageToSend = $"[{DateTime.Now}] {currentUsername} whispered: {message}";
    await Clients.User(userId.ToString()).SendAsync("PrivateMsgReceived", messageToSend);
  }
}
