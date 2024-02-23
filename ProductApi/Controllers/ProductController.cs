using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services.Interfaces;

namespace ProductApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController
{
    private readonly IProductService _productService;


    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetProduct()
    {
        return await _productService.GetAllAsync();
    }
}
