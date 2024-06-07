using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_mediatR_demo.Events.Notifications;

namespace _02_mediatR_demo.Models;

public class User : BaseEntity
{
  public long Id { get; set; }
  public string UserName { get; set; }
  public DateTime CreatedDateTime { get; set; }
  public string Password { get; set; }

  public User(string userName, string password)
  {
    UserName = userName;
    Password = password;
    CreatedDateTime = DateTime.Now;
    AddDomainEvent(new NewUserNotification(UserName, CreatedDateTime)); // register new user notification
  }

  public void ChangePassword(string password)
  {
    Password = password;
  }

  public void ChangeUserName(string userName)
  {
    string oldUserName = UserName;
    UserName = userName;
    AddDomainEvent(new ChangeUserNameNotification(oldUserName, UserName)); // register change username notification
  }
}
