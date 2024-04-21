using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoDI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoDI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoMeaninglessDIController : ControllerBase
{
  private readonly BasicMeaninglessService _basicMeaninglessService;
  // private readonly SlowService _slowService; // this is not appropriate because the service will take time to construct
  public DemoMeaninglessDIController(
    BasicMeaninglessService basicMeaninglessService
  // SlowService slowService
  )
  {
    _basicMeaninglessService = basicMeaninglessService;
    // _slowService = slowService;
  }

  [HttpGet]
  public int RunService(int i1, int i2)
  {
    return _basicMeaninglessService.Add(i1, i2);
  }

  [HttpGet]
  public int RunSlowService(
    [FromServices] SlowService slowService // if the service is ever used in this api, use [FromServices] attribute
  )
  {
    return slowService.Count;
  }
}
