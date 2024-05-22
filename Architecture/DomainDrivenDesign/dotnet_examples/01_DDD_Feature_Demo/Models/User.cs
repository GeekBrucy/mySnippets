using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_DDD_Feature_Demo.Helpers;


namespace _01_DDD_Feature_Demo.Models;

// Rich Domain Model
public class User
{
  public int Id { get; init; } // only set value in constructor
  public DateTime CreatedDateTime { get; init; } // only set value in constructor
  public string UserName { get; private set; }
  public int Credits { get; private set; }
  private string? passwordHash; // need to be mapped to db but no access in the app

  private string? remark;
  public string? Remark { get { return remark; } }
  public string? Tag { get; set; } // not mapped to db

  private User() // empty constructor for EF Core
  { }

  public User(string inconsistentUsernameFieldName)
  {
    UserName = inconsistentUsernameFieldName;
    CreatedDateTime = DateTime.Now;
    Credits = 10;
  }

  public void ChangeUserName(string newValue)
  {
    UserName = newValue;
  }

  public void ChangePassword(string newValue)
  {
    if (newValue.Length < 6)
    {
      throw new ArgumentException("Password too short");
    }
    passwordHash = HashHelper.ComputeMd5Hash(newValue);
  }
}
