using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.Dtos;
using WebAPI.Core.Interfaces;
using WebAPI.Core.Model;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HomeController : ControllerBase
{
  private readonly IBrainstormSessionRepository _sessionRepo;

  public HomeController(IBrainstormSessionRepository sessionRepo)
  {
    _sessionRepo = sessionRepo;
  }

  [HttpPost]
  public async Task<IActionResult> AddNewSession(NewSessionModel reqPayload)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    var newSession = new BrainstormSession
    {
      DateCreated = DateTimeOffset.UtcNow,
      Name = reqPayload.SessionName
    };

    await _sessionRepo.AddAsync(newSession);

    return Ok(newSession);
  }

  [HttpGet]
  public async Task<IActionResult> ListSessions()
  {
    var sessionList = await _sessionRepo.ListAsync();
    var viewModels = sessionList.Select(s => new StormSessionViewModel(s.Id, s.Name, s.DateCreated, s.Ideas.Count));

    return Ok(viewModels);
  }
}
