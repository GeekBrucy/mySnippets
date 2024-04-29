using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionFilterUseCase_AutoTransaction.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class NoTransactionalAttribute : Attribute
{

}
