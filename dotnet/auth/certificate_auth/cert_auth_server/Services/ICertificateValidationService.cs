using System.Security.Cryptography.X509Certificates;

namespace cert_auth_server.Services
{
  public interface ICertificateValidationService
  {
    bool ValidateCertificate(X509Certificate2 clientCertificate);
  }
}