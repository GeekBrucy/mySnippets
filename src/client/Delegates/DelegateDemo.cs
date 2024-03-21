using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client.Delegates;

public static class DelegateDemo
{
  public static void Run()
  {
    DelegateLib.D1 d1 = NormalFunctions.F1;

    d1();
    d1 = NormalFunctions.F2;
    d1();

    DelegateLib.D2 d2 = NormalFunctions.Add;

    var r = d2(1, 2);
    Console.WriteLine(r);
  }
}