using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client.Delegates;

public static class NormalFunctions
{
  public static void F1()
  {
    Console.WriteLine("I am F1");
  }
  public static void F2()
  {
    Console.WriteLine("I am F2");
  }
  public static int Add(int i1, int i2)
  {
    return i1 + i2;
  }
  public static string F3(int i, int j)
  {
    return "xxx";
  }
  public static void F4(int i, string j)
  {
    Console.WriteLine($"i = {i}, j = {j}");
  }
}