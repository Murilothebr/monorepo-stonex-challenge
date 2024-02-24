using ProductApi.Entities;

namespace ProductApi.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();

    Task<Product?> GetProductAsync(string id);

    Task CreateProductAsync(Product newProduct);

    Task UpdateProductAsync(string id, Product updatedProduct);

    Task RemoveProductAsync(string productId);
}
