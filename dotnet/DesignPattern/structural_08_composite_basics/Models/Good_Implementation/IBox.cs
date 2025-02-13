using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace structural_08_composite_basics.Models.Good_Implementation
{
  public interface IBox
  {
    void Process();
    void Add(IBox box);
    void Remove(IBox box);
  }
}