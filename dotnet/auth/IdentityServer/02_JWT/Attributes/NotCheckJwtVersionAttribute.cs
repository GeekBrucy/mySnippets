using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_JWT.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class NotCheckJwtVersionAttribute : Attribute
{

}
