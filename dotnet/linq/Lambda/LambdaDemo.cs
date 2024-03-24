using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client.Lambda;

public static class LambdaDemo
{
  public static void Run()
  {
    Action f1 = delegate ()
    {
      Console.WriteLine("I am lambda demo");
    };

    f1();

    Action<string, int> f2 = delegate (string n, int i)
    {
      Console.WriteLine($"n = {n}, i = {i}");
    };
    f2("f2", 2);

    Action<string, int> f22 = (n, i) => Console.WriteLine($"n = {n}, i = {i}");
    f22("f2", 2);

    Func<int, int, int> f3 = delegate (int i, int j)
    {
      return i + j;
    };
    Console.WriteLine(f3(1, 2));

    Func<int, int, int> f4 = (int i, int j) =>
    {
      return i + j;
    };
    Console.WriteLine(f4(3, 4));

    Func<int, int, int> f5 = (i, j) =>
    {
      return i + j;
    };
    Console.WriteLine(f5(3, 4));

    Func<int, int, int> f6 = (i, j) => i + j;

    Console.WriteLine(f6(3, 4));
  }
}
