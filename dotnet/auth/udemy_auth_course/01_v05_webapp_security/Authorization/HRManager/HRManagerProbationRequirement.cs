using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace _01_v05_webapp_security.Authorization.HRManager;

public class HRManagerProbationRequirement : IAuthorizationRequirement
{
  public HRManagerProbationRequirement(int probationMonths)
  {
    ProbationMonths = probationMonths;
  }

  public int ProbationMonths { get; }
}
