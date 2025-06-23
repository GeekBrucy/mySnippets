using System.Security.Cryptography.X509Certificates;
using cert_auth_client.Models;

namespace cert_auth_client.Services
{
  public class CertificateStoreService : ICertificateService
  {
    private readonly CertificateConfig _config;

    public CertificateStoreService(CertificateConfig config)
    {
      _config = config;
    }

    public X509Certificate2? LoadCertificate()
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
          var certificate = certificates[0];
          Console.WriteLine($"✅ Found certificate in store: {certificate.Subject}");
          Console.WriteLine($"   Issuer: {certificate.Issuer}");
          Console.WriteLine($"   Thumbprint: {certificate.Thumbprint}");
          return certificate;
        }
        else
        {
          Console.WriteLine($"❌ No certificate found in store with criteria: {_config.FindType} = {_config.FindValue}");
          return null;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"❌ Error loading certificate from store: {ex.Message}");
        return null;
      }
    }

    public string GetServiceName() => "Certificate Store Service";
  }
}