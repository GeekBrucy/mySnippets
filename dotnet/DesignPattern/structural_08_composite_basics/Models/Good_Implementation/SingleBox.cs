using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_08_composite_basics.Models.Good_Implementation
{
  public class SingleBox : IBox
  {
    public void Add(IBox box)
    {
    }

    public void Process()
    {

    }

    public void Remove(IBox box)
    {
    }
  }
}