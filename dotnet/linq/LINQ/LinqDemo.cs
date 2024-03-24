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
    var testData = new EmployeeFaker().Generate(10);

    // DemoWhere(testData);
    // DemoCount(testData);
    // DemoAny(testData);
    // DemoSingle(testData);
    // DemoSingleOrDefault(testData);
    // DemoFirst(testData);
    // DemoFirstOrDefault(testData);
    // DemoOrderBy(testData);
    // DemoOrderByDescending(testData);
    // DemoMultipleOrder(testData);
    DemoSkipTake(testData);
  }

  private static void PrintList(IEnumerable<Employee> testData)
  {
    foreach (var item in testData)
    {
      Console.WriteLine(item);
    }
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

  static void DemoFirst(IEnumerable<Employee> testData)
  {
    try
    {
      Console.WriteLine(testData.First(e => e.Age > 300));
    }
    catch (Exception e)
    {
      // if there is no match, it will throw exception
      Console.WriteLine("Not found");
    }
  }
  static void DemoFirstOrDefault(IEnumerable<Employee> testData)
  {
    Console.WriteLine(testData.FirstOrDefault(e => e.Age > 300));
  }
  static void DemoOrderBy(IEnumerable<Employee> testData)
  {
    foreach (var item in testData.OrderBy(e => e.Age))
    {
      Console.WriteLine(item);
    }

    var nums = new int[] { 3, 9, 6, 5, 10, 7 };
    foreach (var item in nums.OrderBy(i => i))
    {
      Console.WriteLine(item);
    }
  }

  static void DemoOrderByDescending(IEnumerable<Employee> testData)
  {
    foreach (var item in testData.OrderByDescending(e => e.Age))
    {
      Console.WriteLine(item);
    }
  }
  static void DemoMultipleOrder(IEnumerable<Employee> testData)
  {
    var ordered = testData.OrderBy(e => e.Age).ThenBy(e => e.Salary);
    PrintList(ordered);
  }

  static void DemoSkipTake(IEnumerable<Employee> testData)
  {
    var data = testData.Skip(3).Take(2);
    PrintList(data);
  }
}
