using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
  [HttpGet]
  public Person GetPerson()
  {
    return new Person("Test", 18);
  }

  [HttpPost]
  public string[] SaveNote(SaveNoteRequest req)
  {
    System.IO.File.WriteAllText($"{req.Title}.txt", req.Content);

    return new string[] { "ok", req.Title };
  }
}
