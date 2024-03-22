using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client.LINQ;

public class MyBasicLINQ
{
  public static void Run()
  {
    int[] nums = new int[] { 2, 3, 232, 2, 2, 32, 23, 213, 3254, 343 };

    IEnumerable<int> res = Where(nums, a => a > 10);

    foreach (var r in res)
    {
      Console.WriteLine(r);
    }
    Console.WriteLine(new string('-', 20));

    IEnumerable<int> res2 = WhereYield(nums, a => a > 10);

    foreach (var r in res2)
    {
      Console.WriteLine($"Print: {r}");
    }
    Console.WriteLine(new string('-', 20));
  }

  public static IEnumerable<int> Where(IEnumerable<int> items, Func<int, bool> f)
  {
    List<int> result = new List<int>();
    foreach (int i in items)
    {
      if (f(i) == true)
      {
        result.Add(i);
      }
    }

    return result;
  }
  public static IEnumerable<int> WhereYield(IEnumerable<int> items, Func<int, bool> f)
  {
    foreach (int i in items)
    {
      if (f(i) == true)
      {
        Console.WriteLine($"Yield: {i}");
        yield return i;
      }
    }
  }
}
