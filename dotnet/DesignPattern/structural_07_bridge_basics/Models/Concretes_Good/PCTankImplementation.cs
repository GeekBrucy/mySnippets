using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using structural_07_bridge_basics.Models.Abstracts_Good;

namespace structural_07_bridge_basics.Models.Concretes_Good
{
  public class PCTankImplementation : TankPlatformImplementation
  {
    public override void DoShot()
    {
      Console.WriteLine("PC DoShot");
    }

    public override void DrawTank()
    {
      Console.WriteLine("PC DrawTank");
    }

    public override void MoveTankTo(Point to)
    {
      Console.WriteLine("PC MoveTankTo");
    }
  }
}