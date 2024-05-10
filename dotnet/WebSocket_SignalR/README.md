# WebSocket

Based on TCP

# SignalR Push mode

- Websocket
- Server-sent Event
- long polling

It will try the options above in order

## Potential Problem 1

When using SignalR in distributed servers, the first conversation may go to server 1, and at this step, the connection ID will be generated, then next conversation may go to server 2, this will cause problem

### Solutions

- Sticky Session:
- Skip negotiation?

## Potential Problem 2

There 4 clients, client 1, 2, 3 ,4. There are 2 distributed servers, server 1, 2.

Client 1, 2 connect to server 1, client 3, 4 connect to server 2. Both connections are websocket. When client 1 send message to server 1, the response message won't be broadcast to client 3, 4, because they connect to server 2

### Solution

All servers connect to a message middleware and enable sticky session or skip negotiation

Official solution: Redis backplane. Nuget: `Microsoft.AspNetCore.SignalR.StackExchangeRedis

```c#
builder.Services.AddSignalR().AddStackExchangeRedis("127.0.0.1", opt =>
{
    opt.Configuration.ChannelPrefix = "Test1_";
});
```
