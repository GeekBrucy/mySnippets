using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creational_03_builder_basics.Models.Abstracts;

namespace creational_03_builder_basics.Models.Houses
{
  public class FarmHouseBuilder : AbstractBuilder
  {
    public override void BuildDoor()
    {
      Console.WriteLine("Building Door...");
    }

    public override void BuildFloor()
    {
      Console.WriteLine("Building Floor...");
    }

    public override void BuildHouseCeiling()
    {
      Console.WriteLine("Building Ceiling...");
    }

    public override void BuildWall()
    {
      Console.WriteLine("Building Wall...");
    }

    public override void BuildWindows()
    {
      Console.WriteLine("Building Windows...");
    }

    public override AbstractHouse GetHouse()
    {
      return new FarmHouse();
    }
  }
}