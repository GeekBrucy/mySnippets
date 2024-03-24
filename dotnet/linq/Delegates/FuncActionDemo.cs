using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client.Delegates;

public static class FuncDemo
{
  public static void Run()
  {
    Func<int, int, int> f = NormalFunctions.Add;

    Console.WriteLine(f(5, 8));

    Func<int, int, string> f2 = NormalFunctions.F3;
    Console.WriteLine(f2(5, 9));
  }
}