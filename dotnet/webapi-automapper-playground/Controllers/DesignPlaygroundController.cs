using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi_automapper_playground.Models.InterchangeableModels;
using webapi_automapper_playground.Services.Feature1;

namespace webapi_automapper_playground.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DesignPlaygroundController : ControllerBase
{
  private readonly ISearchService _feature1Service;
  private readonly IMapper _mapper;
  public DesignPlaygroundController(
    ISearchService feature1Service,
    IMapper mapper
  )
  {
    _feature1Service = feature1Service;
    _mapper = mapper;
  }

  [HttpGet]
  public void TestServiceStructure()
  {
    _feature1Service.Run();
  }

  [HttpGet]
  public void FunnyModelTest()
  {
    var masterData = new DBMasterData
    {
      MasterProp1 = 1,
      MasterProp2 = 2,
      PreviousMasterId = 3,
      PreviousSubId = 4,
    };

    var masterDTO = _mapper.Map<MasterDataDTO>(masterData);
    Console.WriteLine(masterDTO.DataDTO.GetType().Name);
  }
}
