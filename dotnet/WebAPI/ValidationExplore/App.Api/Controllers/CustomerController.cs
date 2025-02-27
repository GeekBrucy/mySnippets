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
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            Console.WriteLine(new string('@', 50));
            Console.WriteLine(ModelState.IsValid);
            Console.WriteLine(new string('@', 50));
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            // Save customer to database

            return Ok();
        }
    }
}