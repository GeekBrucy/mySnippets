using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_DDD_Feature_Demo.Data;
using _01_DDD_Feature_Demo.DTOs;
using _01_DDD_Feature_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_DDD_Feature_Demo.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DemoController : ControllerBase
{
  private readonly MyDbContext _myDbContext;
  public DemoController(MyDbContext myDbContext)
  {
    _myDbContext = myDbContext;
  }

  [HttpPost]
  public async Task<ActionResult<Shop>> CreateShop([FromBody] CreateShopDto newShop)
  {
    var shop = new Shop
    {
      Name = newShop.Name,
      Location = newShop.Location
    };

    _myDbContext.Shops.Add(shop);
    await _myDbContext.SaveChangesAsync();

    return new OkObjectResult(shop);
  }

  [HttpGet]
  public async Task<ActionResult<Shop>> GetShop(int id)
  {
    var shop = await _myDbContext.Shops.FindAsync(id);

    return new OkObjectResult(shop);
  }

  [HttpPost]
  public async Task<ActionResult<Product>> CreateProduct([FromBody] CreateProductDto newProduct) // how to handle enum in dto???
  {
    var product = new Product
    {
      Name = newProduct.Name,
      Price = newProduct.Price,
      CurrencyUnit = newProduct.CurrencyUnit
    };

    _myDbContext.Products.Add(product);
    await _myDbContext.SaveChangesAsync();

    return new OkObjectResult(product);
  }

  [HttpGet]
  public async Task<ActionResult<Product>> GetProduct(int id)
  {
    var product = await _myDbContext.Products.FindAsync(id);

    return new OkObjectResult(product);
  }
}
