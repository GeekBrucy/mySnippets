using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")] // RPC require this format
public class RPCStyleController : ControllerBase
{
  /*
  // if for some reason, the function has to be public, add [ApiExplorerSettings(IgnoreApi=true)]
  public void Read()
  {
    Console.WriteLine("This will cause Swagger error");
  }
  */
  [HttpGet]
  public Person[] GetAll()
  {
    return new Person[] { new Person("test", 1) };
  }

  [HttpGet]
  public Person GetById(long id)
  {
    if (id == 1)
    {
      return new Person("test", (int)id);
    }
    else
    {
      return null;
    }
  }
  [HttpPost]
  public string AddPerson(Person p)
  {
    return "Added";
  }
}
