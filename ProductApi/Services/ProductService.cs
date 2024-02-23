using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductApi.Models;
using ProductApi.Services.Interfaces;

namespace ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;

    public ProductService(IOptions<ProductDatabaseSettings> userWalletDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            userWalletDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            userWalletDatabaseSettings.Value.DatabaseName);

        _productCollection = mongoDatabase.GetCollection<Product>(
            userWalletDatabaseSettings.Value.ProductsCollectionName);
    }

    public Task CreateAsync(Product newProduct)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string productId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, Product updatedProduct)
    {
        throw new NotImplementedException();
    }
}
