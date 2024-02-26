using Microsoft.AspNetCore.Mvc;
using ProductApi.Entities;
using ProductApi.Services.Interfaces;

namespace ProductApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(string id)
    {
        try
        {
            var product = await _productService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound(); 
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); 
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        try
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct(Product product)
    {
        try
        {
            await _productService.CreateProductAsync(product);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); 
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateProduct(string id, Product newProduct)
    {
        try
        {
            await _productService.UpdateProductAsync(id, newProduct);
            return Ok(); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); 
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveProductAsync(string id)
    {
        try
        {
            await _productService.RemoveProductAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); 
        }
    }
}