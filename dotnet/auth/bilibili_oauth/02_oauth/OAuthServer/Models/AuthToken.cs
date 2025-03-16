using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuthServer.Models
{
    public class AuthToken
    {
        public string access_token { get; internal set; }
        public string token_type { get; internal set; }
    }
}