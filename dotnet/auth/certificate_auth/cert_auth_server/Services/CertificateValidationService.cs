using System.Security.Cryptography.X509Certificates;
using cert_auth_server.Models;
using Microsoft.Extensions.Options;

namespace cert_auth_server.Services
{
  public class CertificateValidationService : ICertificateValidationService
  {
    private readonly List<TrustedCertificate> _trustedCertificates;

    public CertificateValidationService(IOptions<List<TrustedCertificate>> trustedCertificates)
    {
      _trustedCertificates = trustedCertificates.Value ?? new List<TrustedCertificate>();
      Console.WriteLine($"🔧 [Validation Service] Loaded {_trustedCertificates.Count} trusted certificates");
      foreach (var cert in _trustedCertificates)
      {
        Console.WriteLine($"   Trusted: Issuer='{cert.Issuer}', Thumbprint='{cert.Thumbprint}'");
      }
    }

    public bool ValidateCertificate(X509Certificate2 clientCertificate)
    {
      Console.WriteLine("🔍 [Validation Service] Starting certificate validation");

      if (clientCertificate == null)
      {
        Console.WriteLine("❌ [Validation Service] Client certificate is null");
        return false;
      }

      Console.WriteLine($"   Client Certificate Subject: {clientCertificate.Subject}");
      Console.WriteLine($"   Client Certificate Issuer: {clientCertificate.Issuer}");
      Console.WriteLine($"   Client Certificate Thumbprint: {clientCertificate.Thumbprint}");

      // 检查证书是否在受信任列表中
      foreach (var trustedCert in _trustedCertificates)
      {
        Console.WriteLine($"   Comparing with trusted certificate:");
        Console.WriteLine($"     Expected Issuer: {trustedCert.Issuer}");
        Console.WriteLine($"     Expected Thumbprint: {trustedCert.Thumbprint}");

        var issuerMatch = string.Equals(trustedCert.Issuer, clientCertificate.Issuer, StringComparison.OrdinalIgnoreCase);
        var thumbprintMatch = string.Equals(trustedCert.Thumbprint, clientCertificate.Thumbprint, StringComparison.OrdinalIgnoreCase);

        Console.WriteLine($"     Issuer Match: {issuerMatch}");
        Console.WriteLine($"     Thumbprint Match: {thumbprintMatch}");

        if (issuerMatch && thumbprintMatch)
        {
          Console.WriteLine("✅ [Validation Service] Certificate validation successful");
          return true;
        }
      }

      Console.WriteLine("❌ [Validation Service] Certificate not found in trusted list");
      return false;
    }
  }
}