using Microsoft.AspNetCore.Mvc;
using ProductApi.Entities;
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
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _productService.GetAllProductsAsync();
    }

    [HttpPost]
    public async Task CreateProduct(Product newProduct)
    {
        await _productService.CreateProductAsync(newProduct);
    }

    [HttpDelete]
    public async Task RemoveProductAsync(string id)
    {
        await _productService.RemoveProductAsync(id);
    }
}
