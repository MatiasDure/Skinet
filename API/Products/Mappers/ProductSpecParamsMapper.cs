using System;
using API.Products.Requests;
using Application.Products.Queries.ListProducts;

namespace API.Products.Mappers;

public static class ProductSpecParamsMapper
{
    public static ProductSpecParams ToParams(ProductParamsRequest request)
    {
        var brands = request.Brands?
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToList() ?? [];

        var types = request.Types?
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToList() ?? [];

        return new ProductSpecParams(brands, types, request.Sort);
    }
}
