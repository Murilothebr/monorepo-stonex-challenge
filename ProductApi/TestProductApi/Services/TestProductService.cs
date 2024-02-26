using FluentValidation.Results;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductApi.Controllers;
using ProductApi.Entities;
using ProductApi.Repository.Interface;
using ProductApi.Services;
using ProductApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProductApi.Services;

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
    public async Task CreateProduct_ThrowsValidationException_WhenSKUIsNotUnique()
    {
        var product = new Product { SKU = "existing_sku" };
        _mockProductValidator.Setup(validator => validator.ValidateAsync(product, It.IsAny<CancellationToken>()))
                             .ReturnsAsync(new FluentValidation.Results.ValidationResult());

        _mockProductRepository.Setup(repo => repo.GetOneAsyncBySku(product.SKU))
                              .ReturnsAsync(product);

        await Assert.ThrowsAsync<ValidationException>(() => _productService.CreateProductAsync(product));
    }
}

