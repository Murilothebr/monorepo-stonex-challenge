using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

public class Product : BaseEntity
{
    [Required(ErrorMessage = "Name is required")]
    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "SKU is required")]
    [BsonElement("SKU")]
    public string SKU { get; set; } = null!;

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    [BsonElement("Price")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Stock is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative number")]
    [BsonElement("Stock")]
    public int Stock { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [BsonElement("Description")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "At least one Image URL is required")]
    [MinLength(1, ErrorMessage = "At least one Image URL is required")]
    [BsonElement("ImageUrl")]
    public List<string> ImageUrls { get; set; } = null!;

    [Required(ErrorMessage = "At least one tag is required")]
    [MinLength(1, ErrorMessage = "At least one tag is required")]
    [BsonElement("Tags")]
    public List<string> Tags { get; set; } = null!;

    [Required(ErrorMessage = "At least one session is required")]
    [MinLength(1, ErrorMessage = "At least one session is required")]
    [BsonElement("Session")]
    public List<string> Sessions { get; set; } = null!;

    public object productId => Id.ToString();
    public bool InStock => Stock > 0;
}
