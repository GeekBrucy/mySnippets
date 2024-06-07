using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_mediatR_demo.Events.Notifications;
using MediatR;

namespace _02_mediatR_demo.Events.Handlers;

public class NewUserHandler : NotificationHandler<NewUserNotification>
{
  protected override void Handle(NewUserNotification notification)
  {
    Console.WriteLine($"New user is created: {notification.UserName}");
  }
}
