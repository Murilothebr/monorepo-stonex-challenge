using ProductApi.Models;

namespace ProductApi.Services.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();

    Task<Product?> GetAsync(string id);

    Task CreateAsync(Product newProduct);

    Task UpdateAsync(string id, Product updatedProduct);

    Task RemoveAsync(string productId);
}
