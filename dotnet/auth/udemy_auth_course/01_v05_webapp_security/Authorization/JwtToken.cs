using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _01_v05_webapp_security.Authorization;

public class JwtToken
{
  [JsonProperty("access_token")]
  public string AccessToken { get; set; } = string.Empty;
  [JsonProperty("expires_at")]
  public DateTime ExpiresAt { get; set; }
}
