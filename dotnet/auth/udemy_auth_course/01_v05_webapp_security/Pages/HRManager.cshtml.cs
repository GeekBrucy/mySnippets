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
        var httpClient = _httpClientFactory.CreateClient(HttpClientNames.TestWebAPI);

        // get token
        var res = await httpClient.PostAsJsonAsync("auth", new Credential { UserName = "admin", Password = "password" });
        res.EnsureSuccessStatusCode();
        string strJwt = await res.Content.ReadAsStringAsync();
        var token = JsonConvert.DeserializeObject<JwtToken>(strJwt);

        // attach token to header
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token?.AccessToken ?? string.Empty);
        weatherForecastItems = await httpClient.GetFromJsonAsync<List<WeatherForecastDTO>>("WeatherForecast") ?? new List<WeatherForecastDTO>();
    }
}
