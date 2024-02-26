using FluentValidation;
using ProductApi.Entities;
using ProductApi.Repository.Interface;
using ProductApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoRepository<Product> _productRepository;
        private readonly IValidator<Product> _productValidator;

        public ProductService(IMongoRepository<Product> productRepository, IValidator<Product> productValidator)
        {
            _productRepository = productRepository;
            _productValidator = productValidator;
        }

        public async Task<bool> isProductSKUnique(string sku)
            => await _productRepository.GetOneAsyncBySku(sku) == null ? true : false;

        public async Task<Product> GetProductAsync(string id)
            => await _productRepository.GetOneAsync(id);

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
            => await _productRepository.GetAllAsync();

        public async Task RemoveProductAsync(string productId)
            => await _productRepository.DeleteOneAsync(productId);

        public async Task CreateProductAsync(Product newProduct)
        {
            var validationResult = await _productValidator.ValidateAsync(newProduct);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if (! await isProductSKUnique(newProduct.SKU))
                throw new ValidationException("Sku must be unique");

            await _productRepository.InsertOneAsync(newProduct);
        }

        public async Task UpdateProductAsync(string id, Product updatedProduct)
        {
            var validationResult = await _productValidator.ValidateAsync(updatedProduct);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            if (! await isProductSKUnique(updatedProduct.SKU))
                throw new ValidationException("Sku must be unique");

            await _productRepository.UpdateOneAsync(id, updatedProduct);
        }
    }
}
