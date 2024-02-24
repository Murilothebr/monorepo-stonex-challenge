using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Entities;

public class Product : BaseEntity
{
    [Required]
    public string SKU { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public List<string> ImageUrl { get; set; } = null!;

    public bool InStock => Stock > 0;
}

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.SKU).Length(0, 10);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to zero");
        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock must be valid number");
        RuleFor(x => x.ImageUrl).NotNull().NotEmpty().WithMessage("Product must have a image");
    }
}