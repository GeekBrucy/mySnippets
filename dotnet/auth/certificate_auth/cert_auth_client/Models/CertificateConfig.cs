namespace cert_auth_client.Models
{
  public class CertificateConfig
  {
    public string StoreName { get; set; } = "My";
    public string StoreLocation { get; set; } = "CurrentUser";
    public string FindType { get; set; } = "FindBySubjectName";
    public string FindValue { get; set; } = string.Empty;
    public string? CertificatePath { get; set; }
    public string? PrivateKeyPath { get; set; }
    public string? Password { get; set; }
  }
}