using FluentValidation;
using FluentValidation.Results;
using MongoDB.Bson;
using Moq;
using ProductApi.Entities;
using ProductApi.Repository.Interface;
using ProductApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestProductApi.Services
{
    public class TestProductService
    {
        private readonly Mock<IMongoRepository<Product>> _mockProductRepository;
        private readonly Mock<IValidator<Product>> _mockProductValidator;
        private readonly ProductService _productService;

        public TestProductService()
        {
            _mockProductRepository = new Mock<IMongoRepository<Product>>();
            _mockProductValidator = new Mock<IValidator<Product>>();
            _productService = new ProductService(_mockProductRepository.Object, _mockProductValidator.Object);
        }


        [Fact]
        public async Task isProductSKUnique_ReturnsTrue_WhenSKUisUnique()
        {
            var sku = "unique_sku";
            _mockProductRepository.Setup(repo => repo.GetOneAsyncBySku(sku))
                                  .ReturnsAsync((Product)null);

            var result = await _productService.isProductSKUnique(sku);

            Assert.True(result);
        }

        [Fact]
        public async Task isProductSKUnique_ReturnsFalse_WhenSKUisNotUnique()
        {
            var sku = "existing_sku";
            _mockProductRepository.Setup(repo => repo.GetOneAsyncBySku(sku))
                                  .ReturnsAsync(new Product());

            var result = await _productService.isProductSKUnique(sku);

            Assert.False(result);
        }

        [Fact]
        public async Task GetAllProductsAsync_ReturnsListOfProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = new ObjectId("65dbd6dca52827c42cfa095b"), Name = "Product 1" },
                new Product { Id = new ObjectId("65dbd6dca52827c42cfa095c"), Name = "Product 2" },
                new Product { Id = new ObjectId("65dbd6dca52827c42cfa095d"), Name = "Product 3" }
            };
            _mockProductRepository.Setup(repo => repo.GetAllAsync())
                                  .ReturnsAsync(products);

            var result = await _productService.GetAllProductsAsync();

            Assert.NotNull(result);
            Assert.Equal(products.Count, result.Count());
        }

        [Fact]
        public async Task RemoveProductAsync_RemovesProduct_WhenFound()
        {
            var productId = "65dbcd120b70d0cec57d5893";

            await _productService.RemoveProductAsync(productId);

            _mockProductRepository.Verify(repo => repo.DeleteOneAsync(productId), Times.Once);
        }

        // ALL NEGATIVE TESTS

        [Fact]
        public async Task RemoveProductAsync_ThrowsException_WhenRepositoryFailsToDelete()
        {
            var productId = "65dbd6dca52827c42cfa095b";
            _mockProductRepository.Setup(repo => repo.GetOneAsync(productId))
                                  .ReturnsAsync(new Product { Id = new ObjectId(productId) });
            _mockProductRepository.Setup(repo => repo.DeleteOneAsync(productId))
                                  .ThrowsAsync(new Exception("Failed to delete product"));

            await Assert.ThrowsAsync<Exception>(() => _productService.RemoveProductAsync(productId));
        }

        [Fact]
        public async Task CreateProduct_ThrowsValidationException_WhenSKUIsNotUnique()
        {
            var product = new Product { SKU = "323112" };
            _mockProductValidator.Setup(validator => validator.ValidateAsync(product, default))
                                 .ReturnsAsync(new ValidationResult());

            _mockProductRepository.Setup(repo => repo.GetOneAsyncBySku(product.SKU))
                                  .ReturnsAsync(product);

            await Assert.ThrowsAsync<ValidationException>(() => _productService.CreateProductAsync(product));
        }

        [Fact]
        public async Task CreateProduct_ThrowsValidationException_WhenProductIsInvalid()
        {
            var product = new Product { SKU = "323" };
            var validationErrors = new List<ValidationFailure> { new ValidationFailure("Name", "Name is required.") };
            var validationResult = new ValidationResult(validationErrors);

            _mockProductValidator.Setup(validator => validator.ValidateAsync(product, default))
                                 .ReturnsAsync(validationResult);

            await Assert.ThrowsAsync<ValidationException>(() => _productService.CreateProductAsync(product));
        }

        [Fact]
        public async Task UpdateProduct_ThrowsValidationException_WhenSKUIsNotUnique()
        {
            var productId = "65dbd6dca52827c42cfa095b";
            var updatedProduct = new Product { Id = new ObjectId(productId), SKU = "323112" };

            _mockProductValidator.Setup(validator => validator.ValidateAsync(updatedProduct, default))
                                 .ReturnsAsync(new ValidationResult());

            _mockProductRepository.Setup(repo => repo.GetOneAsyncBySku(updatedProduct.SKU))
                                  .ReturnsAsync(new Product { Id = new ObjectId("65dbd6dca52827c42cfa095d") });

            await Assert.ThrowsAsync<ValidationException>(() => _productService.UpdateProductAsync(productId, updatedProduct));
        }

        [Fact]
        public async Task UpdateProduct_ThrowsValidationException_WhenProductIsInvalid()
        {
            var productId = "65dbd6dca52827c42cfa095b";
            var updatedProduct = new Product { Id = new ObjectId(productId), SKU = "323112" };
            var validationErrors = new List<ValidationFailure> { new ValidationFailure("Name", "Name is required.") };
            var validationResult = new ValidationResult(validationErrors);

            _mockProductValidator.Setup(validator => validator.ValidateAsync(updatedProduct, default))
                                 .ReturnsAsync(validationResult);

            await Assert.ThrowsAsync<ValidationException>(() => _productService.UpdateProductAsync(productId, updatedProduct));
        }

        [Fact]
        public async Task GetProductAsync_ReturnsProduct_WhenFound()
        {
            var productId = "65dbcd120b70d0cec57d5893";
            var product = new Product { Id = new ObjectId(productId), Name = "Product" };
            _mockProductRepository.Setup(repo => repo.GetOneAsync(productId))
                                  .ReturnsAsync(product);

            var result = await _productService.GetProductAsync(productId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetProductAsync_ReturnsNull_WhenNotFound()
        {
            var productId = "nonexistent_id";
            _mockProductRepository.Setup(repo => repo.GetOneAsync(productId))
                                  .ReturnsAsync((Product)null);

            var result = await _productService.GetProductAsync(productId);

            Assert.Null(result);
        }
    }
}
