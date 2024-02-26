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

        [Fact]
        public async Task GetProduct_ReturnsNotFound_WhenProductNotFound()
        {
            // Arrange
            string productId = "nonexistent_id";
            _mockProductService.Setup(service => service.GetProductAsync(productId))
                               .ReturnsAsync((Product)null);

            // Act
            var result = await _productController.GetProduct(productId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetProduct_ReturnsOk_WhenProductFound()
        {
            // Arrange
            string productId = "existing_id";
            var mockProduct = new Product { Id = new ObjectId(productId), Name = "Test Product" };
            _mockProductService.Setup(service => service.GetProductAsync(productId))
                               .ReturnsAsync(mockProduct);

            // Act
            var result = await _productController.GetProduct(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProduct = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(mockProduct, returnedProduct);
        }

        [Fact]
        public async Task RemoveProduct_ReturnsOk()
        {
            string productId = "existing_id";

            var result = await _productController.RemoveProductAsync(productId);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task RemoveProduct_ReturnsStatusCode500_WhenServiceThrowsException()
        {
            string productId = "existing_id";
            _mockProductService.Setup(service => service.RemoveProductAsync(productId))
                               .ThrowsAsync(new Exception("Simulated exception"));

            var result = await _productController.RemoveProductAsync(productId);

            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
