using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using ActionFilterUseCase_AutoTransaction.Attributes;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilterUseCase_AutoTransaction.Filters;

public class TransactionScopeFilter : IAsyncActionFilter
{
  public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
    /*
    context.ActionDescriptor: Action description
    context.ActionArguments: Action argument info
    */
    bool hasNoTransactionalAttribute = false;
    if (context.ActionDescriptor is ControllerActionDescriptor)
    {
      var actionDesc = context.ActionDescriptor as ControllerActionDescriptor;
      hasNoTransactionalAttribute = actionDesc.MethodInfo.IsDefined(typeof(NoTransactionalAttribute), false);
      /*
      actionDesc.MethodInfo.GetCustomAttributes(typeof(NoTransactionalAttribute), false).Any();
      this can achieve same goal as line 24 does
      */
    }
    if (hasNoTransactionalAttribute)
    {
      await next();
      return;
    }
    using var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
    var result = await next();
    if (result.Exception == null)
    {
      txScope.Complete();
    }
  }
}
