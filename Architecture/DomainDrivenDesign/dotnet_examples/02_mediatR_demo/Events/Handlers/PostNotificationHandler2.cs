using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_mediatR_demo.Events.Notifications;
using MediatR;

namespace _02_mediatR_demo.Events.Handlers;

public class PostNotificationHandler2 : NotificationHandler<PostNotification>
{
  protected override void Handle(PostNotification notification)
  {
    Console.WriteLine($"[Handled by PostNotificationHandler2 at {DateTime.Now}]: Received message: {notification.body}");
  }
}
