using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _01_v05_webapp_security.Pages.Account;

public class AccessDenied : PageModel
{
    private readonly ILogger<AccessDenied> _logger;

    public AccessDenied(ILogger<AccessDenied> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
