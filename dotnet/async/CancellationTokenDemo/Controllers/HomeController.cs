using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CancellationTokenDemo.Models;

namespace CancellationTokenDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // the cancellationToken is from the framework
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        // close tab or leave the index page, the cancellation token will be triggered
        await Download("https://books.toscrape.com/", 100, cancellationToken);
        return View();
    }

    static async Task Download(string url, int n, CancellationToken cancellationToken)
    {
        using HttpClient httpClient = new HttpClient();

        for (var i = 0; i < n; i++)
        {
            var resp = await httpClient.GetAsync(url, cancellationToken);
            string html = await resp.Content.ReadAsStringAsync();
            Debug.WriteLine(html.Substring(0, 20));
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
