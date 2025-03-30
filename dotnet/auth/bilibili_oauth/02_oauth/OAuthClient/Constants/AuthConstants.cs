using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuthClient.Constants
{
    public class AuthConstants
    {
        public const string cookieScheme = "cookie-client";
        public const string oauthScheme = "custom-oauth";
        public const string clientId = "explore";
        public const string clientSecret = "client-secret";
        public const string authEndpoint = "https://localhost:5005/oauth/authorize";
        public const string tokenEndpoint = "https://localhost:5005/oauth/token";
        public const string userInfoEndpoint = "https://localhost:5005/oauth/userInfo";
        public const string refreshTokenEndpoint = "https://localhost:5005/oauth/RefreshToken";
        public const string oauthCallback = "/auth/callback";
    }
}