using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi_automapper_playground.Models.Model1;
using webapi_automapper_playground.Models.Model1.Nested;
using webapi_automapper_playground.Models.Model2;

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

  [HttpGet]
  public NestedTargetParent NestedMap()
  {
    var src = new NestedSourceParent
    {
      SourceParentProp = "SourceParentProp",
      SourceChild1 = new NestedSourceChild1
      {
        SourceChild1Prop1 = "SourceChild1Prop1"
      },
      SourceChildren1 = [
        new NestedSourceChild
        {
          SourceChildProp1 = "SourceChildProp1",
          SourceChildProp2 = "SourceChildProp2"
        }
      ]
    };

    return _mapper.Map<NestedTargetParent>(src);
  }

  [HttpGet]
  public TargetModel2Parent1 MapGrandChild()
  {
    var source = new SourceModel2Parent
    {
      SourceChildren = new List<SourceModel2Child>
      {
        new SourceModel2Child
        {
          SourceChildProp1 = 1,
          SourceChildProp2 = 2,
          SourceChildProp3 = 3,
          SourceChildProp4 = 4,
          SourceChildProp5 = 5,
          SourceChildProp6 = 6,
          SourceChildProp7 = 7,
          Type = "Type1",
        },
        new SourceModel2Child
        {
          SourceChildProp1 = 1,
          SourceChildProp2 = 22,
          SourceChildProp3 = 33,
          SourceChildProp4 = 44,
          SourceChildProp5 = 55,
          SourceChildProp6 = 66,
          SourceChildProp7 = 77,
          Type = "Type1",
        },
        new SourceModel2Child
        {
          SourceChildProp1 = 1,
          SourceChildProp2 = 222,
          SourceChildProp3 = 333,
          SourceChildProp4 = 444,
          SourceChildProp5 = 555,
          SourceChildProp6 = 666,
          SourceChildProp7 = 777,
          Type = "Type1",
        },
        new SourceModel2Child
        {
          SourceChildProp1 = 1,
          SourceChildProp2 = 2222,
          SourceChildProp3 = 3333,
          SourceChildProp4 = 4444,
          SourceChildProp5 = 5555,
          SourceChildProp6 = 6666,
          SourceChildProp7 = 7777,
          Type = "Type2",
        },
      }
    };

    return _mapper.Map<TargetModel2Parent1>(source);
  }

  [HttpGet]
  public TargetModel2Parent2 MapGrandChild2()
  {
    var source = new SourceModel2Parent
    {
      SourceChildren = new List<SourceModel2Child>
      {
        new SourceModel2Child
        {
          SourceChildProp1 = 1,
          SourceChildProp2 = 2,
          SourceChildProp3 = 3,
          SourceChildProp4 = 4,
          SourceChildProp5 = 5,
          SourceChildProp6 = 6,
          SourceChildProp7 = 7,
          Type = "Type1",
        },
        new SourceModel2Child
        {
          SourceChildProp1 = 2,
          SourceChildProp2 = 22,
          SourceChildProp3 = 33,
          SourceChildProp4 = 44,
          SourceChildProp5 = 55,
          SourceChildProp6 = 66,
          SourceChildProp7 = 77,
          Type = "Type1",
        },
        new SourceModel2Child
        {
          SourceChildProp1 = 1,
          SourceChildProp2 = 222,
          SourceChildProp3 = 333,
          SourceChildProp4 = 444,
          SourceChildProp5 = 555,
          SourceChildProp6 = 666,
          SourceChildProp7 = 777,
          Type = "Type1",
        },
        new SourceModel2Child
        {
          SourceChildProp1 = 1,
          SourceChildProp2 = 2222,
          SourceChildProp3 = 3333,
          SourceChildProp4 = 4444,
          SourceChildProp5 = 5555,
          SourceChildProp6 = 6666,
          SourceChildProp7 = 7777,
          Type = "Type2",
        },
      }
    };
    return _mapper.Map<TargetModel2Parent2>(source);
  }
}
