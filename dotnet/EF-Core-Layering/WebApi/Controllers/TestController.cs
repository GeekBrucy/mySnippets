using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EntityLib.Data;
using EntityLib.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TestController : ControllerBase
{
  private readonly MyDbContext _dbContext;
  public TestController(MyDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  [HttpGet]
  public void TestSetup()
  {
    if (_dbContext.Database.CanConnect())
    {
      Console.WriteLine("db connected");
    }
  }

  [HttpPost]
  public async Task<ActionResult<Book>> SaveBook(BookDto book)
  {
    Book b = JsonSerializer.Deserialize<Book>(JsonSerializer.Serialize(book));
    _dbContext.Books.Add(b);
    await _dbContext.SaveChangesAsync();

    return b;
  }
}
