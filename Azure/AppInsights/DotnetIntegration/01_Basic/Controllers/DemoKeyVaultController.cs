using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;

namespace _01_Basic.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoKeyVaultController : ControllerBase
{
  private readonly SecretClient _secretClient;
  public DemoKeyVaultController(SecretClient secretClient)
  {
    _secretClient = secretClient;
  }
  [HttpGet]
  public ActionResult GetSecret(string key)
  {
    return new OkObjectResult(_secretClient.GetSecret(key).Value);
  }
}
