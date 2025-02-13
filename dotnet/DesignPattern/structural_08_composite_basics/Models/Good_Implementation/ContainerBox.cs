using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_08_composite_basics.Models.Good_Implementation
{
  public class ContainerBox : IBox
  {
    private List<IBox> Boxes = new List<IBox>();
    public void Add(IBox box)
    {
      Boxes.Add(box);
    }
    public void Remove(IBox box)
    {
      Boxes.Remove(box);
    }

    public void Process()
    {
      foreach (var box in Boxes)
      {
        box.Process();
      }
    }
  }
}