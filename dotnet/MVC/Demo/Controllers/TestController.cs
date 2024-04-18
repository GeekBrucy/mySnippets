using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Demo11()
    {
        var p = new Person("test", true, DateTime.Now);
        return View(p);
    }
}
