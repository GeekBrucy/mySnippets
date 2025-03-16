using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using OAuthServer.Constants;
using OAuthServer.Models;

namespace OAuthServer.Controllers
{
    public class OAuthController : Controller
    {
        private static readonly RSA key = RSA.Create();
        public IDataProtectionProvider _provider;
        public OAuthController(IDataProtectionProvider provider)
        {
            _provider = provider;
        }

        [Authorize(AuthConstants.AuthedPolicy)]
        public bool authorize()
        {
            var result = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            var client_id = "";
            var redirect_uri = "";
            var code_challenge = "";
            var code_challenge_method = "";
            var state = "";
            foreach (var key in result.AllKeys)
            {
                switch (key)
                {
                    case "client_id":
                        client_id = result[key];
                        break;
                    case "redirect_uri":
                        redirect_uri = result[key];
                        break;
                    case "code_challenge":
                        code_challenge = result[key];
                        break;
                    case "code_challenge_method":
                        code_challenge_method = result[key];
                        break;
                    case "state":
                        state = result[key];
                        break;
                    default:
                        break;
                }
            }
            var protector = _provider.CreateProtector(AuthConstants.OAuthDataProtectionPurpose);
            var code = new AuthCode
            {
                ClientId = client_id,
                CodeChallenge = code_challenge,
                CodeChallengeMethod = code_challenge_method,
                RedirectUri = redirect_uri,
                Expiry = DateTime.Now.AddMinutes(5)
            };
            var codeStr = protector.Protect(JsonSerializer.Serialize(code));

            Response.Redirect($"{redirect_uri}?code={codeStr}&state={state}&iss={AuthConstants.OAuthSub}");
            return true;
        }
        public async Task<object> token()
        {
            var body = await Request.BodyReader.ReadAsync();

            var content = Encoding.UTF8.GetString(body.Buffer);

            string grantType = "";
            string code = "";
            string redirectUri = "";
            string codeVerify = "";
            foreach (var part in content.Split('&'))
            {
                var subParts = part.Split('=');
                var key = subParts[0];
                var value = subParts[1];
                switch (key)
                {
                    case "grant_type":
                        grantType = value;
                        break;
                    case "code":
                        code = value;
                        break;
                    case "redirect_uri":
                        redirectUri = value;
                        break;
                    case "code_verifier":
                        codeVerify = value;
                        break;
                    default:
                        break;
                }
            }
            var protect = _provider.CreateProtector(AuthConstants.OAuthDataProtectionPurpose);

            var codeStr = protect.Unprotect(code);

            var authCode = JsonSerializer.Deserialize<AuthCode>(codeStr);

            if (!ValidateCode(authCode, codeVerify))
            {
                return null;
            }

            var secret = new RsaSecurityKey(key);
            var jwt = new JsonWebTokenHandler().CreateToken
            (
                new SecurityTokenDescriptor()
                {
                    Audience = AuthConstants.OAuthAudience,
                    Subject = new ClaimsIdentity
                    (
                        new List<Claim>
                        {
                            new Claim("sub", AuthConstants.OAuthSub),
                            new Claim("custom", "test-custom")
                        }
                    ),
                    Expires = DateTime.Now.AddMinutes(15),
                    TokenType = AuthConstants.TokenType,
                    SigningCredentials = new SigningCredentials(secret, SecurityAlgorithms.RsaSha256)
                }
            );

            return new AuthToken
            {
                access_token = jwt,
                token_type = AuthConstants.TokenType
            };
        }

        public static bool ValidateCode(AuthCode code, string codeVerify)
        {

            var sha256 = SHA256.Create();
            var verifiedCode = Base64UrlEncoder.Encode
            (
                sha256.ComputeHash(Encoding.ASCII.GetBytes(codeVerify))
            );

            return verifiedCode.Equals(code.CodeChallenge);
        }
    }
}