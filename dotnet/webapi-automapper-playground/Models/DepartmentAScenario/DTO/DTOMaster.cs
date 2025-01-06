using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_automapper_playground.Models.DepartmentAScenario.DTO;

public class DTOMaster
{
  public ICollection<DTOChildTypeOne1> DTOChildTypeOne1s { get; set; } = new Collection<DTOChildTypeOne1>();
  public ICollection<DTOChildTypeOne2> DTOChildTypeOne2s { get; set; } = new Collection<DTOChildTypeOne2>();
  public ICollection<DTOChildTypeOne3> DTOChildTypeOne3s { get; set; } = new Collection<DTOChildTypeOne3>();
  public ICollection<DTOChildTypeOne4> DTOChildTypeOne4s { get; set; } = new Collection<DTOChildTypeOne4>();
  public ICollection<DTOChildTypeOne5> DTOChildTypeOne5s { get; set; } = new Collection<DTOChildTypeOne5>();
}
