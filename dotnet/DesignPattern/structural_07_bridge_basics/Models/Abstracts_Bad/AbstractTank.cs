using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_07_bridge_basics.Models.Abstracts_Bad
{
  public abstract class AbstractTank
  {
    public abstract void Shot();
    public abstract void Run();
    public abstract void Turn();
  }
}