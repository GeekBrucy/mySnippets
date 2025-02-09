using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using structural_07_bridge_basics.Models.Abstracts_Good;

namespace structural_07_bridge_basics.Models.Concretes_Good
{
  public class T50 : AbstractTank
  {
    public T50(TankPlatformImplementation tankPlatformImplementation) : base(tankPlatformImplementation)
    {
    }

    public override void Run()
    {
      // ...
      _tankPlatformImplementation.MoveTankTo(new Point());
      // ...
    }

    public override void Shot()
    {
      // ...
      _tankPlatformImplementation.DoShot();
      // ...
    }

    public override void Turn()
    {
      // ...
      _tankPlatformImplementation.DrawTank();
      // ...
    }
  }
}