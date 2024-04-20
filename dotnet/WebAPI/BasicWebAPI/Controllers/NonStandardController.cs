using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers;

/// <summary>
/// Traditionally, the api controller will inherit from ControllerBase
/// This NonStandardController demoed a controller that is not inheriting from that. NOT RECOMMENDED
/// 
/// the [ApiController] and [Route("[controller]/[action]")] attributes are the keys
/// but this approach cannot use HTTP status or redirect, and need to unit test in a different way
/// </summary>
[ApiController]
[Route("[controller]/[action]")]
public class NonStandardController
{
  [HttpGet]
  public int Add(int i, int j)
  {
    return i + j;
  }
}
