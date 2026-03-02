using System;
using FluentValidation;

namespace API.Products.Requests.Create;

public class CreateProductRequestValidator: AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("What is going on");
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.PictureUrl).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.QuantityInStock).GreaterThan(0);
    }
}
