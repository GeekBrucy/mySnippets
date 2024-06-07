using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_mediatR_demo.Models;

public class User
{
  public long Id { get; set; }
  public string UserName { get; set; }
  public DateTime CreatedDateTime { get; set; }
  public string Password { get; set; }

  public User(string userName)
  {
    UserName = userName;
    CreatedDateTime = DateTime.Now;
  }

  public void ChangePassword(string password)
  {
    Password = password;
  }

  public void ChangeUserName(string userName)
  {
    UserName = userName;
  }
}
