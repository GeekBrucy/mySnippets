using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi_automapper_playground.Services.Feature1;

namespace webapi_automapper_playground.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DesignPlaygroundController : ControllerBase
{
  private readonly ISearchService _feature1Service;
  public DesignPlaygroundController(
    ISearchService feature1Service
  )
  {
    _feature1Service = feature1Service;
  }

  [HttpGet]
  public void TestServiceStructure()
  {
    _feature1Service.Run();
  }
}
