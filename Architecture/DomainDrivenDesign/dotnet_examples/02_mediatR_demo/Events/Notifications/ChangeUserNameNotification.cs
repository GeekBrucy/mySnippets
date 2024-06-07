using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace _02_mediatR_demo.Events.Notifications;

public record ChangeUserNameNotification(string oldUserName, string newUserName) : INotification;