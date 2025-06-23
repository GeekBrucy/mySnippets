using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace cert_auth_server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CertificateTestController : ControllerBase
  {
    [HttpGet("no-cert")]
    public IActionResult Get()
    {
      Console.WriteLine("🔍 [Controller] /certificate-test/no-cert called");
      Console.WriteLine($"   User Authenticated: {User.Identity?.IsAuthenticated}");
      Console.WriteLine($"   Authentication Type: {User.Identity?.AuthenticationType}");

      return Ok("No certificate required");
    }

    [Authorize]
    [HttpGet("cert")]
    public IActionResult GetWithCert()
    {
      Console.WriteLine("🔍 [Controller] /certificate-test/cert called");
      Console.WriteLine($"   User Authenticated: {User.Identity?.IsAuthenticated}");
      Console.WriteLine($"   Authentication Type: {User.Identity?.AuthenticationType}");

      // 获取客户端证书信息
      var certificate = HttpContext.Connection.ClientCertificate;
      var userClaims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

      Console.WriteLine($"   Has Client Certificate: {certificate != null}");
      if (certificate != null)
      {
        Console.WriteLine($"   Certificate Subject: {certificate.Subject}");
        Console.WriteLine($"   Certificate Issuer: {certificate.Issuer}");
        Console.WriteLine($"   Certificate Thumbprint: {certificate.Thumbprint}");
      }

      Console.WriteLine($"   User Claims Count: {userClaims.Count}");
      foreach (var claim in userClaims)
      {
        Console.WriteLine($"     Claim: {claim.Type} = {claim.Value}");
      }

      var response = new
      {
        Message = "Certificate required and validated",
        CertificateInfo = certificate != null ? new
        {
          Subject = certificate.Subject,
          Issuer = certificate.Issuer,
          Thumbprint = certificate.Thumbprint,
          NotBefore = certificate.NotBefore,
          NotAfter = certificate.NotAfter,
          SerialNumber = certificate.SerialNumber
        } : null,
        UserClaims = userClaims,
        AuthenticationInfo = new
        {
          IsAuthenticated = User.Identity?.IsAuthenticated,
          AuthenticationType = User.Identity?.AuthenticationType,
          Name = User.Identity?.Name
        }
      };

      return Ok(response);
    }
  }
}