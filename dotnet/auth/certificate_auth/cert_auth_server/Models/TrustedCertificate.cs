namespace cert_auth_server.Models
{
  public class TrustedCertificate
  {
    public string Issuer { get; set; } = string.Empty;
    public string Thumbprint { get; set; } = string.Empty;
  }
}