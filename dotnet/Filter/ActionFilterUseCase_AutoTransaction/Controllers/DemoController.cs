using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActionFilterUseCase_AutoTransaction.Data;
using ActionFilterUseCase_AutoTransaction.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilterUseCase_AutoTransaction.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoController : ControllerBase
{
  private readonly MyDbContext _ctx;
  public DemoController(MyDbContext ctx)
  {
    _ctx = ctx;
  }

  [HttpGet]
  public IEnumerable<Book> Test()
  {
    return _ctx.Books;
  }
}
