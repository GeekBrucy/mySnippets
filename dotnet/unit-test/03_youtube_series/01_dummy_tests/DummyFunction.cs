using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_dummy_tests;

public class DummyFunction
{
  public string ReturnRandomStr(int num)
  {
    if (num == 0)
    {
      return "Zero";
    }
    else
    {
      return "Not Zero";
    }
  }
}
