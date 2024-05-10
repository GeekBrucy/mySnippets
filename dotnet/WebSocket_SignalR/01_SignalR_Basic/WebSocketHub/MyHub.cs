using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace _01_SignalR_Basic.WebSocketHub;

public class MyHub : Hub
{
  public Task SendPublicMsg(string msg)
  {
    string connId = Context.ConnectionId;
    string msgToSend = $"{connId} {DateTime.Now}: {msg}";
    return Clients.All.SendAsync("PublicMsgReceived", msgToSend);
  }
}
