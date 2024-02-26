using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using ProductApi.Controllers;
using ProductApi.Entities;
using ProductApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestProductApi.Controller
{
    public class TestProductController
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly ProductController _productController;

        public TestProductController()
        {
            _mockProductService = new Mock<IProductService>();
            _productController = new ProductController(_mockProductService.Object);
        }

        // ALL POSITIVE TESTS

        [Fact]
        public async Task GetProduct_ReturnsOk_WhenProductFound()
        {
            string productId = "65dbd6dca52827c42cfa095b";
            var mockProduct = new Product { Id = new ObjectId(productId), Name = "Test Product" };
            _mockProductService.Setup(service => service.GetProductAsync(productId))
                               .ReturnsAsync(mockProduct);

            var result = await _productController.GetProduct(productId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProduct = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(mockProduct, returnedProduct);
        }

        [Fact]
        public async Task RemoveProduct_ReturnsOk()
        {
            string productId = "65dbd6dca52827c42cfa095b";

            var result = await _productController.RemoveProductAsync(productId);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateProduct_ReturnsOk()
        {
            string productId = "65dbd6dca52827c42cfa095b";
            var updatedProduct = new Product { Id = new ObjectId(productId), Name = "Updated Product" };

            var result = await _productController.UpdateProduct(productId, updatedProduct);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetAllProducts_ReturnsOk_WithProducts()
        {

            var mockProducts = new List<Product>
            {
                new Product { Id = new ObjectId("65dbd6dca52827c42cfa095b"), Name = "Product 1" },
                new Product { Id = new ObjectId("65dbd6dca52827c42cfa095c"), Name = "Product 2" },
                new Product { Id = new ObjectId("65dbd6dca52827c42cfa095d"), Name = "Product 3" }
            };
            _mockProductService.Setup(service => service.GetAllProductsAsync())
                               .ReturnsAsync(mockProducts);

            var result = await _productController.GetAllProducts();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProducts = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal(mockProducts, returnedProducts);
        }

        [Fact]
        public async Task CreateProduct_ReturnsOk()
        {

            var newProduct = new Product { Name = "New Product" };

            var result = await _productController.CreateProduct(newProduct);

            Assert.IsType<OkResult>(result);
        }

        // ALL NEGATIVE TESTS

        [Fact]
        public async Task UpdateProduct_ReturnsStatusCode500_WhenServiceThrowsException()
        {
            string productId = "65dbd6dca52827c42cfa095b";
            var updatedProduct = new Product { Id = new ObjectId(productId), Name = "Updated Product" };
            _mockProductService.Setup(service => service.UpdateProductAsync(productId, updatedProduct))
                               .ThrowsAsync(new Exception("Simulated exception"));

            var result = await _productController.UpdateProduct(productId, updatedProduct);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_ReturnsStatusCode500_WhenProductServiceThrowsException()
        {
            var newProduct = new Product { Name = "New Product" };
            _mockProductService.Setup(service => service.CreateProductAsync(newProduct))
                               .ThrowsAsync(new Exception("Simulated exception"));

            var result = await _productController.CreateProduct(newProduct);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetProduct_ReturnsNotFound_WhenProductNotFound()
        {
            string productId = "nonexistent_id";
            _mockProductService.Setup(service => service.GetProductAsync(productId))
                               .ReturnsAsync((Product)null);

            var result = await _productController.GetProduct(productId);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task RemoveProduct_ReturnsStatusCode500_WhenServiceThrowsException()
        {
            string productId = "65dbd6dca52827c42cfa095b";
            _mockProductService.Setup(service => service.RemoveProductAsync(productId))
                               .ThrowsAsync(new Exception("Simulated exception"));

            var result = await _productController.RemoveProductAsync(productId);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetAllProducts_ReturnsStatusCode500_WhenServiceThrowsException()
        {

            _mockProductService.Setup(service => service.GetAllProductsAsync())
                               .ThrowsAsync(new Exception("Simulated exception"));

            var result = await _productController.GetAllProducts();

            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
