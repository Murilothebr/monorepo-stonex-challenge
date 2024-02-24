using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductApi.Entities;
using ProductApi.Repository.Interface;
using ProductApi.Services.Interfaces;
using System;

namespace ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IMongoRepository<Product> _productRepository;

    public ProductService(IMongoRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task CreateProductAsync(Product newProduct)
        => await _productRepository.InsertOneAsync(newProduct);

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
        => await _productRepository.GetAllAsync();

    public async Task<Product?> GetProductAsync(string id)
        => await _productRepository.GetOneAsync(id);

    public Task RemoveProductAsync(string productId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(string id, Product updatedProduct)
    {
        throw new NotImplementedException();
    }
}
