using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models;

public class TestModel
{
  public int Id { get; set; }
  public TestParent MyProp { get; set; }
}

public class TestParent
{
  public Child1? Child1 { get; set; }
  public Child2? Child2 { get; set; }
  public Child3? Child3 { get; set; }
  public Child4? Child4 { get; set; }
}

public class Child1
{ }
public class Child2
{ }
public class Child3
{ }
public class Child4
{ }