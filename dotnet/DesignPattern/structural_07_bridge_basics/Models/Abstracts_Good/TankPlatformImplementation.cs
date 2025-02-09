using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace structural_07_bridge_basics.Models.Abstracts_Good
{
  public abstract class TankPlatformImplementation
  {
    public abstract void MoveTankTo(Point to);
    public abstract void DrawTank();
    public abstract void DoShot();
  }
}