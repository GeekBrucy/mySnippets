using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return Ok("Certificate required");
        }
    }
}