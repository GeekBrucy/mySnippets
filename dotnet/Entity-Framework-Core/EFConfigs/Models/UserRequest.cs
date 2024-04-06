using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFConfigs.Models.Enums;

namespace EFConfigs.Models;

public class UserRequest
{
  public long Id { get; set; }
  public UserRequestType Type { get; set; }
  public User RequestedBy { get; set; }
  public User? ApprovedBy { get; set; }
  public string Comments { get; set; }
  public UserRequestStatus Status { get; set; }
}
