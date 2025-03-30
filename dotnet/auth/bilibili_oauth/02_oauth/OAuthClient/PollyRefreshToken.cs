using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using OAuthClient.Constants;
using Polly;

namespace OAuthClient
{
    public class PollyRefreshToken
    {
        private readonly TokenManage _tokenManage;
        private readonly HttpClient _httpClient;

        public PollyRefreshToken(TokenManage tokenManage, HttpClient httpClient)
        {
            _tokenManage = tokenManage;
            _httpClient = httpClient;
        }

        public async Task<string> GetInfo(string name)
        {
            var tokenInfo = _tokenManage.Get(name);
            var request = new HttpRequestMessage(HttpMethod.Get, AuthConstants.userInfoEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenInfo.AccessToken);

            request.Headers.Add("name", name);

            var result = await _httpClient.SendAsync(request);

            var content = await result.Content.ReadAsStringAsync(); ;

            return content;
        }

        public static IAsyncPolicy<HttpResponseMessage> HandleUnAuthorized
        (
            IServiceProvider servicerProvider,
            HttpRequestMessage requestMessage
        )
        {
            return Policy.HandleResult<HttpResponseMessage>(resp =>
            {
                return resp.StatusCode == HttpStatusCode.Unauthorized;
            }).RetryAsync(1, async (e, attempt) =>
            {
                var scope = servicerProvider.CreateScope();
                var token = scope.ServiceProvider.GetRequiredService<TokenManage>();
                var refresh = scope.ServiceProvider.GetRequiredService<Refresh>();

                var name = requestMessage.Headers.GetValues("name").First();

                var tokenInfo = token.Get(name);
                var result = await refresh.RefreshToken(tokenInfo);

                token.Save(name, new TokenManage.TokenInfo(result.AccessToken, result.RefreshToken, Convert.ToDateTime(result.ExpiresIn)));

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
            });
        }
    }
}