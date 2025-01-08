using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using _01_v05_webapp_security.Authorization;
using _01_v05_webapp_security.Contants;
using _01_v05_webapp_security.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _01_v05_webapp_security.Pages;

[Authorize(Policy = "HRManagerOnly")]
public class HRManager : PageModel
{
    private readonly ILogger<HRManager> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    [BindProperty]
    public List<WeatherForecastDTO> weatherForecastItems { get; set; } = new List<WeatherForecastDTO>();

    public HRManager(ILogger<HRManager> logger, IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        // get token from session
        JwtToken token = new JwtToken();

        var strTokenObj = HttpContext.Session.GetString("access_token"); // "access_token" actually can be any string

        if (string.IsNullOrEmpty(strTokenObj))
        {
            token = await Authenticate();
        }
        else
        {
            token = JsonConvert.DeserializeObject<JwtToken>(strTokenObj) ?? new JwtToken();
        }

        if (token == null
        || string.IsNullOrEmpty(token.AccessToken)
        || token.ExpiresAt <= DateTime.UtcNow)
        {
            token = await Authenticate();
        }


        var httpClient = _httpClientFactory.CreateClient(HttpClientNames.TestWebAPI);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token?.AccessToken ?? string.Empty);
        weatherForecastItems = await httpClient.GetFromJsonAsync<List<WeatherForecastDTO>>("WeatherForecast") ?? new List<WeatherForecastDTO>();
    }

    private async Task<JwtToken> Authenticate()
    {
        var httpClient = _httpClientFactory.CreateClient(HttpClientNames.TestWebAPI);
        var res = await httpClient.PostAsJsonAsync("auth", new Credential { UserName = "admin", Password = "password" });
        res.EnsureSuccessStatusCode();
        string strJwt = await res.Content.ReadAsStringAsync();
        HttpContext.Session.SetString("access_token", strJwt);
        return JsonConvert.DeserializeObject<JwtToken>(strJwt) ?? new JwtToken();
    }
}
