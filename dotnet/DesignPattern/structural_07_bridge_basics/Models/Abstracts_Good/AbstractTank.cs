using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_07_bridge_basics.Models.Abstracts_Good
{
  public abstract class AbstractTank
  {
    protected TankPlatformImplementation _tankPlatformImplementation;
    public AbstractTank(TankPlatformImplementation tankPlatformImplementation)
    {
      _tankPlatformImplementation = tankPlatformImplementation;
    }
    public abstract void Shot();
    public abstract void Run();
    public abstract void Turn();
  }
}