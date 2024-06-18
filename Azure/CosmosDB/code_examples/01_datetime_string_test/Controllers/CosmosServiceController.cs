using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_datetime_string_test.Models;
using _01_datetime_string_test.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _01_datetime_string_test.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CosmosServiceController : ControllerBase
{
  private readonly ICosmosService _cosmosService;
  public CosmosServiceController(ICosmosService cosmosService)
  {
    _cosmosService = cosmosService;
  }

  [HttpGet]
  public async Task<IEnumerable<TestModel>> GetAll()
  {
    return await _cosmosService.RetrieveAllTestDatasAsync();
  }
}
