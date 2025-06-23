using System.Security.Cryptography.X509Certificates;

namespace cert_auth_client.Services
{
  public interface ICertificateService
  {
    X509Certificate2? LoadCertificate();
    string GetServiceName();
  }
}