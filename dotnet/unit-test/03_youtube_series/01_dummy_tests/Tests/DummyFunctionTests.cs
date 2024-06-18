using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_dummy_tests.Tests;

public static class DummyFunctionTests
{
  // naming convention - ClassName_MethodName_ExpectedResult
  public static void DummyFunction_ReturnRandomStr_ReturnsZeroIf0()
  {
    try
    {
      // Arrange  Go get your variables, whatever you need, your classes, go get functions
      int num = 0;
      DummyFunction dummyFunction = new DummyFunction();

      // Act      Execute the function
      string result = dummyFunction.ReturnRandomStr(num);
      // Assert   Whatever is returned, is it what you want.
      if (result == "Zero")
      {
        Console.WriteLine("Passed");
      }
      else
      {
        Console.WriteLine("Failed");
      }

    }
    catch (Exception e)
    {
      Console.WriteLine(e);
    }
  }
}
