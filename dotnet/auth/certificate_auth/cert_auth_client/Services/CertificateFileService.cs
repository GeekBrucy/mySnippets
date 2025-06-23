using System.Security.Cryptography.X509Certificates;
using cert_auth_client.Models;

namespace cert_auth_client.Services
{
  public class CertificateFileService : ICertificateService
  {
    private readonly CertificateConfig _config;

    public CertificateFileService(CertificateConfig config)
    {
      _config = config;
    }

    public X509Certificate2? LoadCertificate()
    {
      try
      {
        if (string.IsNullOrEmpty(_config.CertificatePath))
        {
          Console.WriteLine("❌ Certificate path is not configured");
          return null;
        }

        X509Certificate2 certificate;

        // 检查文件扩展名来决定加载方式
        var extension = Path.GetExtension(_config.CertificatePath).ToLowerInvariant();

        if (extension == ".pfx" || extension == ".p12")
        {
          // 从 PFX 文件加载
          if (string.IsNullOrEmpty(_config.Password))
          {
            certificate = new X509Certificate2(_config.CertificatePath);
          }
          else
          {
            certificate = new X509Certificate2(_config.CertificatePath, _config.Password);
          }
        }
        else if (extension == ".pem")
        {
          // 从 PEM 文件加载
          if (!string.IsNullOrEmpty(_config.PrivateKeyPath))
          {
            certificate = X509Certificate2.CreateFromPemFile(_config.CertificatePath, _config.PrivateKeyPath);
          }
          else
          {
            certificate = X509Certificate2.CreateFromPemFile(_config.CertificatePath);
          }
        }
        else
        {
          Console.WriteLine($"❌ Unsupported certificate file format: {extension}");
          return null;
        }

        Console.WriteLine($"✅ Loaded certificate from file: {certificate.Subject}");
        Console.WriteLine($"   Issuer: {certificate.Issuer}");
        Console.WriteLine($"   Thumbprint: {certificate.Thumbprint}");
        return certificate;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"❌ Error loading certificate from file: {ex.Message}");
        return null;
      }
    }

    public string GetServiceName() => "Certificate File Service";
  }
}