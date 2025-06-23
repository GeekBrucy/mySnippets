using System.Security.Cryptography.X509Certificates;
using cert_auth_client.Services;
using cert_auth_client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

class Program
{
  static async Task Main(string[] args)
  {
    Console.WriteLine("Certificate Authentication Client");
    Console.WriteLine("=================================");

    // 构建配置
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

    // 设置依赖注入
    var services = new ServiceCollection();

    // 注册配置
    var certConfig = new CertificateConfig();
    configuration.GetSection("Certificate").Bind(certConfig);
    services.AddSingleton(certConfig);

    // 注册证书服务（可以选择其中一种）
    var certificateMethod = args.Length > 0 ? args[0].ToLowerInvariant() : "hybrid";

    switch (certificateMethod)
    {
      case "store":
        services.AddScoped<ICertificateService, CertificateStoreService>();
        Console.WriteLine("Using Certificate Store Service");
        break;
      case "file":
        services.AddScoped<ICertificateService, CertificateFileService>();
        Console.WriteLine("Using Certificate File Service");
        break;
      case "hybrid":
      default:
        services.AddScoped<ICertificateService, CertificateHybridService>();
        Console.WriteLine("Using Certificate Hybrid Service");
        break;
    }

    var serviceProvider = services.BuildServiceProvider();

    try
    {
      // 获取证书服务
      var certificateService = serviceProvider.GetRequiredService<ICertificateService>();
      Console.WriteLine($"Service: {certificateService.GetServiceName()}");

      // 加载证书
      var clientCertificate = certificateService.LoadCertificate();
      if (clientCertificate == null)
      {
        Console.WriteLine("❌ Failed to load certificate");
        return;
      }

      Console.WriteLine($"✅ Certificate loaded successfully:");
      Console.WriteLine($"   Subject: {clientCertificate.Subject}");
      Console.WriteLine($"   Issuer: {clientCertificate.Issuer}");
      Console.WriteLine($"   Thumbprint: {clientCertificate.Thumbprint}");

      // 创建 HttpClientHandler 并配置客户端证书
      var handler = new HttpClientHandler();
      handler.ClientCertificates.Add(clientCertificate);
      Console.WriteLine($"Added certificate to handler. Certificate count: {handler.ClientCertificates.Count}");

      // 在开发环境中，忽略服务器证书验证（仅用于测试）
      handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

      // 创建 HttpClient
      var serverUrl = configuration["Server:BaseUrl"] ?? "https://localhost:7230/";
      using var httpClient = new HttpClient(handler);
      httpClient.BaseAddress = new Uri(serverUrl);

      // 测试端点
      Console.WriteLine("\nTesting endpoints...");

      // 测试不需要认证的端点
      Console.WriteLine("\n1. Testing endpoint without certificate requirement...");
      try
      {
        var response1 = await httpClient.GetAsync("certificate-test/no-cert");
        var content1 = await response1.Content.ReadAsStringAsync();
        Console.WriteLine($"Status: {response1.StatusCode}");
        Console.WriteLine($"Response: {content1}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }

      // 测试需要认证的端点
      Console.WriteLine("\n2. Testing endpoint with certificate requirement...");
      try
      {
        var response2 = await httpClient.GetAsync("certificate-test/cert");
        var content2 = await response2.Content.ReadAsStringAsync();
        Console.WriteLine($"Status: {response2.StatusCode}");

        if (response2.IsSuccessStatusCode)
        {
          Console.WriteLine("✅ Certificate authentication successful!");
          Console.WriteLine($"Response: {content2}");
        }
        else
        {
          Console.WriteLine($"❌ Certificate authentication failed: {response2.StatusCode}");
          Console.WriteLine($"Response: {content2}");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"❌ Error: {ex.Message}");
      Console.WriteLine($"Stack trace: {ex.StackTrace}");
    }

    Console.WriteLine("\nPress any key to exit...");
    Console.ReadKey();
  }
}
