using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace _02_SignalR_with_jwt.SignalR;

public class MyHub : Hub
{
  public Task SendPublicMsg(string msg)
  {
    string connId = Context.ConnectionId;
    string msgToSend = $"{connId} {DateTime.Now}: {msg}";
    return Clients.All.SendAsync("PublicMsgReceived", msgToSend);
  }
}
