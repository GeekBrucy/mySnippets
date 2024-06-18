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
public class DocumentClientController : ControllerBase
{
  private readonly IDocumentDbService _documentDbService;
  public DocumentClientController(IDocumentDbService documentDbService)
  {
    _documentDbService = documentDbService;
  }

  [HttpGet]
  public async Task<IEnumerable<TestModel>> GetTestModels()
  {
    return await _documentDbService.GetItemsAsync();
  }
}
