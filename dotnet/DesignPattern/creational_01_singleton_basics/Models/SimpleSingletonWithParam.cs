using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace creational_01_singleton_basics.Models
{
  public class SimpleSingletonWithParam
  {
    private static SimpleSingletonWithParam instance;
    private int _x;
    private int _y;

    private SimpleSingletonWithParam(int x, int y)
    {
      _x = x;
      _y = y;
    }

    public static SimpleSingletonWithParam GetInstance(int x, int y)
    {
      if (instance == null)
      {
        instance = new SimpleSingletonWithParam(x, y);
      }
      else
      {
        instance._x = x;
        instance._y = y;
      }

      return instance;
    }
  }
}