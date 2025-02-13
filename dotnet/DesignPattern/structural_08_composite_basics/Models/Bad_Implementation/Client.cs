using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_08_composite_basics.Models.Bad_Implementation
{
  public class Client
  {
    public static void Run()
    {
      List<IBox> boxes = new List<IBox>
      {
        new SingleBox(),
        new ContainerBox(),
        new SingleBox(),
        new ContainerBox(),
        new ContainerBox()
      };

      foreach (var box in boxes)
      {
        // Client code couples with object internal structure
        if (box is ContainerBox)
        {
          box.Process();
          List<IBox> boxList = ((ContainerBox)box).GetBoxes();
          // do stuff
        }
        else if (box is SingleBox)
        {
          box.Process();
        }
      }
    }
  }
}