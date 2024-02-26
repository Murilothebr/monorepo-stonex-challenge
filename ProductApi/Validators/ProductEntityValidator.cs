using FluentValidation;
using ProductApi.Entities;
using ProductApi.Services.Interfaces;

namespace ProductApi.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.SKU).NotEmpty().Length(5, 20).WithMessage("SKU must be between 5 and 20 characters");
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to zero");
        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock must be a non-negative number");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.ImageUrls).NotNull().NotEmpty().WithMessage("At least one Image URL is required");
        RuleFor(x => x.ImageUrls).Must(urls => urls != null && urls.Count > 0).WithMessage("At least one Image URL is required");
        RuleFor(x => x.Tags).NotNull().NotEmpty().WithMessage("At least one tag is required");
        RuleFor(x => x.Tags).Must(tags => tags != null && tags.Count > 0).WithMessage("At least one tag is required");
        RuleFor(x => x.Sessions).NotNull().NotEmpty().WithMessage("At least one session is required");
        RuleFor(x => x.Sessions).Must(sessions => sessions != null && sessions.Count > 0).WithMessage("At least one session is required");
    }
}
