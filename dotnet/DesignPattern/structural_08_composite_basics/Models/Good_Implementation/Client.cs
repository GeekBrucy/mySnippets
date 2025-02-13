using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_08_composite_basics.Models.Good_Implementation
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
        box.Process();
      }
    }
  }
}