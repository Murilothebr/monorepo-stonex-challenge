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

    public async Task<Product> GetProductAsync(string id)
        => await _productRepository.GetOneAsync(id);

    public async Task CreateProductAsync(Product newProduct)
        => await _productRepository.InsertOneAsync(newProduct);

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
        => await _productRepository.GetAllAsync();

    public async Task RemoveProductAsync(string productId)
        => await _productRepository.DeleteOneAsync(productId);

    public async Task UpdateProductAsync(string id, Product updatedProduct)
        => await _productRepository.UpdateOneAsync(id, updatedProduct);
}
