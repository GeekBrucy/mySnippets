using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoDI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoDI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoMeaninglessDIController : ControllerBase
{
  private readonly BasicMeaninglessService _basicMeaninglessService;
  public DemoMeaninglessDIController(BasicMeaninglessService basicMeaninglessService)
  {
    _basicMeaninglessService = basicMeaninglessService;
  }

  [HttpGet]
  public int RunService(int i1, int i2)
  {
    return _basicMeaninglessService.Add(i1, i2);
  }
}
