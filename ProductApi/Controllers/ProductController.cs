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

    [HttpGet("{id}")]
    public async Task<Product> GetProduct(string id)
    {
        return await _productService.GetProductAsync(id);
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _productService.GetAllProductsAsync();
    }

    [HttpPost]
    public async Task CreateProduct(Product product)
    {
        await _productService.CreateProductAsync(product);
    }

    [HttpPatch]
    public async Task UpdateProduct(string id, Product newProduct)
    {
        await _productService.UpdateProductAsync(id, newProduct);
    }

    [HttpDelete]
    public async Task RemoveProductAsync([FromBody] string id)
    {
        await _productService.RemoveProductAsync(id);
    }
}
