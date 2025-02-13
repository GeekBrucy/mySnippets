using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_08_composite_basics.Models.Bad_Implementation
{
  public class SingleBox : IBox
  {
    public void Process()
    {
      Console.WriteLine("Single box Process...");
    }
  }
}