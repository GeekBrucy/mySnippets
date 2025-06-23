using System.Security.Cryptography.X509Certificates;
using cert_auth_client.Models;

namespace cert_auth_client.Services
{
  public class CertificateHybridService : ICertificateService
  {
    private readonly CertificateConfig _config;

    public CertificateHybridService(CertificateConfig config)
    {
      _config = config;
    }

    public X509Certificate2? LoadCertificate()
    {
      // 方法1：尝试从证书存储加载
      var certificate = LoadFromStore();
      if (certificate != null)
      {
        return certificate;
      }

      // 方法2：尝试从文件加载
      certificate = LoadFromFile();
      if (certificate != null)
      {
        return certificate;
      }

      Console.WriteLine("❌ Failed to load certificate from both store and file");
      return null;
    }

    private X509Certificate2? LoadFromStore()
    {
      try
      {
        var storeName = Enum.Parse<StoreName>(_config.StoreName);
        var storeLocation = Enum.Parse<StoreLocation>(_config.StoreLocation);
        var findType = Enum.Parse<X509FindType>(_config.FindType);

        using var store = new X509Store(storeName, storeLocation);
        store.Open(OpenFlags.ReadOnly);

        var certificates = store.Certificates.Find(findType, _config.FindValue, false);

        if (certificates.Count > 0)
        {
          var cert = certificates[0];
          Console.WriteLine($"✅ Found certificate in store: {cert.Subject}");
          return cert;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"⚠️ Error loading from store: {ex.Message}");
      }

      return null;
    }

    private X509Certificate2? LoadFromFile()
    {
      try
      {
        if (string.IsNullOrEmpty(_config.CertificatePath))
        {
          return null;
        }

        X509Certificate2 certificate;

        var extension = Path.GetExtension(_config.CertificatePath).ToLowerInvariant();

        if (extension == ".pfx" || extension == ".p12")
        {
          certificate = string.IsNullOrEmpty(_config.Password)
              ? new X509Certificate2(_config.CertificatePath)
              : new X509Certificate2(_config.CertificatePath, _config.Password);
        }
        else if (extension == ".pem")
        {
          certificate = string.IsNullOrEmpty(_config.PrivateKeyPath)
              ? X509Certificate2.CreateFromPemFile(_config.CertificatePath)
              : X509Certificate2.CreateFromPemFile(_config.CertificatePath, _config.PrivateKeyPath);
        }
        else
        {
          return null;
        }

        Console.WriteLine($"✅ Loaded certificate from file: {certificate.Subject}");
        return certificate;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"⚠️ Error loading from file: {ex.Message}");
      }

      return null;
    }

    public string GetServiceName() => "Certificate Hybrid Service";
  }
}