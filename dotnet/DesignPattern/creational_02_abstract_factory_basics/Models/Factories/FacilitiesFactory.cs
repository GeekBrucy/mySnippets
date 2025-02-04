using creational_02_abstract_factory_basics.Models.Abstracts;

namespace creational_02_abstract_factory_basics.Models.Factories
{
  public abstract class FacilitiesFactory
  {
    public abstract Road CreateRoad();
    public abstract Building CreateBuilding();
    public abstract Jungle CreateJungle();
    public abstract Tunnel CreateTunnel();
  }
}