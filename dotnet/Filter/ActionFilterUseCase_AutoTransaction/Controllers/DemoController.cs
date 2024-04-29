using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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

  [HttpPost]
  public string BreakSave()
  {
    using TransactionScope tx = new TransactionScope(); // make the following in same transaction
    _ctx.Persons.Add(new Person { Name = "Test", Age = 19 });
    _ctx.SaveChanges();
    _ctx.Books.Add(new Book { Price = 1 });
    _ctx.SaveChanges();
    tx.Complete();
    return "OK";
  }

  [HttpPost]
  public async Task<string> BreakSaveWithAsync()
  {
    // when dealing with async, need to pass TransactionScopeAsyncFlowOption.Enabled in to TransactionScope
    using TransactionScope tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
    _ctx.Persons.Add(new Person { Name = "Test", Age = 19 });
    await _ctx.SaveChangesAsync();
    _ctx.Books.Add(new Book { Price = 1 });
    await _ctx.SaveChangesAsync();
    tx.Complete();
    return "OK";
  }
}
