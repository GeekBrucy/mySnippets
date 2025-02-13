using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_08_composite_basics.Models.Bad_Implementation
{
  public class ContainerBox : IBox
  {
    public List<IBox> GetBoxes()
    {
      return new List<IBox>
      {
        new SingleBox(),
        new ContainerBox()
        // ...
      };
    }
    public void Process()
    {
      Console.WriteLine("Container Box Process");
    }
  }
}