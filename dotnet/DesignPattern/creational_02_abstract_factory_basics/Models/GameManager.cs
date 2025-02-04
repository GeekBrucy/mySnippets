using creational_02_abstract_factory_basics.Models.Abstracts;
using creational_02_abstract_factory_basics.Models.Factories;

namespace creational_02_abstract_factory_basics.Models
{
  public class GameManager
  {
    private readonly FacilitiesFactory _facilitiesFactory;

    public GameManager(FacilitiesFactory facilitiesFactory)
    {
      _facilitiesFactory = facilitiesFactory;
    }

    public void BuildGameFacilities()
    {
      Road road = _facilitiesFactory.CreateRoad();
      Building building = _facilitiesFactory.CreateBuilding();
      Tunnel tunnel1 = _facilitiesFactory.CreateTunnel();
      Tunnel tunnel2 = _facilitiesFactory.CreateTunnel();
      Jungle jungle = _facilitiesFactory.CreateJungle();

      road.Build();
      building.Build();
      tunnel1.Build();
      tunnel2.Build();
      jungle.Build();
    }

    public void Run()
    {

    }
  }
}