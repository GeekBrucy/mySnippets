using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoRequestBodyController : ControllerBase
{
  [HttpPost]
  /// <summary>
  /// Content-type must be application/json
  /// </summary>
  /// <param name="p1"></param>
  /// <returns></returns>
  public string AddPerson(Person p1)
  {
    return $"Saved {p1}";
  }

  [HttpPut("{id}")]
  /// <summary>
  /// Content-type must be application/json
  /// </summary>
  /// <param name="p1"></param>
  /// <returns></returns>
  public string UpdatePerson([FromRoute] int id, Person p1)
  {
    return $"Updated {id} {p1}";
  }
}
