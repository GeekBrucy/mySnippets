using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using structural_06_Adapter_basics.Interfaces;

namespace structural_06_Adapter_basics.Models
{
  public class Adapter : ITarget
  {
    LegacyClass _adaptee;
    public Adapter(LegacyClass adaptee)
    {
      _adaptee = adaptee;
    }

    public void Request()
    {
      _adaptee.SpecificRequest1();
      _adaptee.SpecificRequest2();
    }
  }
}