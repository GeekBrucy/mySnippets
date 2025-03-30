using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth;
using OAuthClient.Constants;
using static OAuthClient.TokenManage;

namespace OAuthClient
{
    public class Refresh
    {
        private readonly HttpClient _httpClient;

        public Refresh(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<OAuthTokenResponse> RefreshToken(TokenInfo info)
        {
            var tokenParam = new Dictionary<string, string>
            {
                { "client_id", AuthConstants.clientId },
                { "client_secret", AuthConstants.clientSecret },
                { "grant_type", "refresh_token" },
                { "refresh_token", info.RefreshToken }
            };

            var requestContent = new FormUrlEncodedContent(tokenParam);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, AuthConstants.refreshTokenEndpoint)
            {
                Content = requestContent
            };
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Version = _httpClient.DefaultRequestVersion;
            var response = await _httpClient.SendAsync(requestMessage);
            var body = await response.Content.ReadAsStringAsync();

            return OAuthTokenResponse.Success(JsonDocument.Parse(body));
        }
    }
}