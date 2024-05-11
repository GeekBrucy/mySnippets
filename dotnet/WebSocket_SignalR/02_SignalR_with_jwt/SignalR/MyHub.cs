using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace _02_SignalR_with_jwt.SignalR;

[Authorize]
public class MyHub : Hub
{
  public Task SendPublicMsg(string msg)
  {
    var claim = Context.User.FindFirst(ClaimTypes.Name);

    string connId = Context.ConnectionId;
    string msgToSend = $"[{DateTime.Now}] {claim?.Value ?? Context.GetHttpContext().Connection.RemoteIpAddress.ToString()}: {msg} ";
    return Clients.All.SendAsync("PublicMsgReceived", msgToSend);
  }
}
