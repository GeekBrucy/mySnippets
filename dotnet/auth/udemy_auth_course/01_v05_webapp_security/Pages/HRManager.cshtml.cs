using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_v05_webapp_security.Contants;
using _01_v05_webapp_security.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

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

        weatherForecastItems = await httpClient.GetFromJsonAsync<List<WeatherForecastDTO>>("WeatherForecast") ?? new List<WeatherForecastDTO>();
    }
}
