using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_mediatR_demo.Events.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _02_mediatR_demo.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoMediatRBasicController : ControllerBase
{
  private readonly IMediator _mediator;

  public DemoMediatRBasicController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost]
  public ActionResult SendPost(string body)
  {
    _mediator.Publish(new PostNotification($"[Published at {DateTime.Now}]: {body}"));
    return Ok();
  }
}
