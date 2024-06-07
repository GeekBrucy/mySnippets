using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_mediatR_demo.Events.Notifications;
using MediatR;

namespace _02_mediatR_demo.Events.Handlers;

public class ChangeUserNameHandler : NotificationHandler<ChangeUserNameNotification>
{
  protected override void Handle(ChangeUserNameNotification notification)
  {
    Console.WriteLine($"Username is changed: {notification.oldUserName} -> {notification.newUserName}");
  }
}
