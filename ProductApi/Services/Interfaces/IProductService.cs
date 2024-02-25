using ProductApi.Entities;

namespace ProductApi.Services.Interfaces;

public interface IProductService
{
    Task<Product> GetProductAsync(string id);

    Task<IEnumerable<Product>> GetAllProductsAsync();

    Task CreateProductAsync(Product newProduct);

    Task UpdateProductAsync(string id, Product updatedProduct);

    Task RemoveProductAsync(string productId);
}
