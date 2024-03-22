using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using linq.Data;
using linq.Models;

namespace linq.LINQ;

public static class LinqDemo
{
  public static void Run()
  {
    var testData = new EmployeeFaker().Generate(100);

    // DemoWhere(testData);
    // DemoCount(testData);
    // DemoAny(testData);
    // DemoSingle(testData);
    DemoSingleOrDefault(testData);
  }

  static void DemoWhere(IEnumerable<Employee> testData)
  {
    foreach (var item in testData.Where(e => e.Age >= 35))
    {
      Console.WriteLine(item);
    }
  }

  static void DemoCount(IEnumerable<Employee> testData)
  {
    Console.WriteLine
    (
      testData.Count(e => e.Salary > 20000 && e.Age < 35)
    );
  }

  static void DemoAny(IEnumerable<Employee> testData)
  {
    Console.WriteLine
    (
      testData.Any(e => e.Salary > 20000 && e.Age < 35)
    );
  }

  static void DemoSingle(IEnumerable<Employee> testData)
  {
    try
    {
      Console.WriteLine(testData.Single(e => e.Name.Contains("Bruce")));
    }
    catch (Exception)
    {
      // if there are more than 1 records, it will throw exception
      Console.WriteLine("More than 1 records or no record returned!!!");
    }
  }
  static void DemoSingleOrDefault(IEnumerable<Employee> testData)
  {
    try
    {
      Console.WriteLine(testData.SingleOrDefault(e => e.Name.Contains("Bruce")));
    }
    catch (Exception)
    {
      // if there are more than 1 records, it will throw exception
      Console.WriteLine("More than 1 records returned!!!");
    }
  }
}
