using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace _01_v05_webapp_security.Authorization.HRManager;

public class HRManagerProbationRequirementHandler : AuthorizationHandler<HRManagerProbationRequirement>
{
  protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManagerProbationRequirement requirement)
  {
    if (!context.User.HasClaim(x => x.Type == "EmploymentDate"))
      return Task.CompletedTask;

    var isEmploymentDateParsed = DateTime.TryParse
    (
      context.User.FindFirst(x => x.Type == "EmploymentDate")?.Value,
      out DateTime employmentDate
    );

    if (isEmploymentDateParsed)
    {
      var period = DateTime.Now - employmentDate;
      if (period.Days > 30 * requirement.ProbationMonths)
      {
        context.Succeed(requirement);
      }
    }

    return Task.CompletedTask;
  }
}
