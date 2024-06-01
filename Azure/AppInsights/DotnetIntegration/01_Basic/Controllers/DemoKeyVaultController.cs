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
  private readonly IConfiguration _config;
  public DemoKeyVaultController(SecretClient secretClient, IConfiguration config)
  {
    _secretClient = secretClient;
    _config = config;
  }
  [HttpGet]
  public ActionResult GetSecret(string key)
  {
    return new OkObjectResult(_secretClient.GetSecret(key).Value);
  }

  [HttpGet]
  public ActionResult GetSecretFromConfig(string key)
  {
    return new OkObjectResult(_config[key]);
  }
}
