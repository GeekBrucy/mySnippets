using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi_automapper_playground.Models.Model1;

namespace webapi_automapper_playground.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PlaygroundController : ControllerBase
{
  private readonly IMapper _mapper;
  public PlaygroundController(IMapper mapper)
  {
    _mapper = mapper;
  }

  [HttpGet]
  public SimpleTargetModel1 SimpleMap()
  {
    var src = new SimpleSourceModel1
    {
      SourceProp1 = "SourceProp1",
      SourceProp2 = "SourceProp2",
      SourceProp3 = "SourceProp3",
      SourceProp4 = "SourceProp4",
    };

    return _mapper.Map<SimpleTargetModel1>(src);
  }

  [HttpGet]
  public SimpleSourceModel1 SimpleReverseMap()
  {
    var src = new SimpleTargetModel1
    {
      TargetProp1 = "SourceProp1",
      TargetProp2 = "SourceProp2",
      TargetProp3 = "SourceProp3",
      TargetProp4 = "SourceProp4",
    };

    return _mapper.Map<SimpleSourceModel1>(src);
  }
}
