using creational_02_abstract_factory_basics.Models.Abstracts;
using creational_02_abstract_factory_basics.Models.Factories;

namespace creational_02_abstract_factory_basics.Models.ModernStyle
{
  public class ModernFacilities : FacilitiesFactory
  {
    public override Building CreateBuilding()
    {
      return new ModernBuilding();
    }

    public override Jungle CreateJungle()
    {
      return new ModernJungle();
    }

    public override Road CreateRoad()
    {
      return new ModernRoad();
    }

    public override Tunnel CreateTunnel()
    {
      return new ModernTunnel();
    }
  }
}