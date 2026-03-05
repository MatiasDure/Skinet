using System;
using FluentValidation;

namespace API.Products.Requests.List;

public class ProductParamsRequestValidator : AbstractValidator<ProductParamsRequest>
{
    public ProductParamsRequestValidator()
    {
        RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
        RuleFor(x => x.Limit).InclusiveBetween(1, 50);
        RuleFor(x => x.Sort).Must(BeAValidSortOption).When(x => x.Sort != null);
    }

    private static readonly string[] AllowedSorts = [ "priceAsc", "priceDesc"];

    private bool BeAValidSortOption(string? sort) => sort == null || AllowedSorts.Contains(sort);
}
