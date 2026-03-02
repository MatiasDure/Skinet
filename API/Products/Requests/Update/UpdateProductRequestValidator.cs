using System;
using FluentValidation;

namespace API.Products.Requests.Update;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.PictureUrl).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Brand).NotEmpty();
        RuleFor(x => x.QuantityInStock).GreaterThan(0);
    }
}
