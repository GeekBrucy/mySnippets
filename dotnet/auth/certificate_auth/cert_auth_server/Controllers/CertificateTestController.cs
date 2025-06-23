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
            return Ok("No certificate required");
        }

        [Authorize]
        [HttpGet("cert")]
        public IActionResult GetWithCert()
        {
            // 获取客户端证书信息
            var certificate = HttpContext.Connection.ClientCertificate;
            var userClaims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

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
                UserClaims = userClaims
            };

            return Ok(response);
        }
    }
}