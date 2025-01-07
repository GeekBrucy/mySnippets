using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _01_v05_webapp_security.Pages;

[Authorize(Policy = "MustBelongToHRDepartment")]
public class HumanResource : PageModel
{
    private readonly ILogger<HumanResource> _logger;

    public HumanResource(ILogger<HumanResource> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
