using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dumpify;
using ef_core_with_mapper_lib.DBContexts;
using ef_core_with_mapper_lib.Models.DBModels;
using ef_core_with_mapper_lib.Models.PayloadModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ef_core_with_mapper.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TestController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly AppDBContext _ctx;
  public TestController(IMapper mapper, AppDBContext ctx)
  {
    _mapper = mapper;
    _ctx = ctx;
  }
  [HttpPost]
  public async Task<ActionResult<Library>> CreateLibrary(LibraryFE newLib)
  {
    var lib = _mapper.Map<Library>(newLib);
    lib.Dump();
    await _ctx.Libraries.AddAsync(lib);
    await _ctx.SaveChangesAsync();

    return lib;
  }

  [HttpPut]
  public async Task<ActionResult<Library>> UpdateLibrary(LibraryFE libFE)
  {
    var lib = await _ctx.Libraries
      .Include(l => l.Books)
      .ThenInclude(b => b.Chapters)
      .FirstAsync(l => l.Id == libFE.LibraryId);
    if (lib == null)
    {
      return NotFound();
    }
    _mapper.Map(libFE, lib);
    await _ctx.SaveChangesAsync();

    return lib;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Library>> GetLibrary(int id)
  {
    var lib = await _ctx.Libraries
      .Include(l => l.Books)
      .ThenInclude(b => b.Chapters)
      .FirstAsync(l => l.Id == id);

    if (lib == null)
    {
      return NotFound();
    }

    return Ok(lib);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteLibrary(int id)
  {
    var lib = await _ctx.Libraries.FindAsync(id);

    if (lib == null)
    {
      return NotFound();
    }

    _ctx.Libraries.Remove(lib);

    await _ctx.SaveChangesAsync();

    return Ok();
  }
}
