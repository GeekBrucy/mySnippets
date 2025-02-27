using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            // If the model is invalid, FluentValidation will automatically return a 400 Bad Request
            // with validation error details.
            return Ok("Order created successfully.");
        }
    }
}