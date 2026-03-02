using System;
using API.Products.Requests;
using Application.Products.Queries.ListProducts;

namespace API.Products.Mappers;

public static class ProductSpecParamsMapper
{
    private const int MAX_LIMIT = 50; 
    private const int MIN_LIMIT = 1; 
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

        var page = request.Page < 1 ? 1 : request.Page;
        var limit = request.Limit;

        if(limit > MAX_LIMIT) 
            limit = MAX_LIMIT;
        else if(limit < MIN_LIMIT)
            limit = MIN_LIMIT;
        
        return new ProductSpecParams(
            brands, 
            types, 
            request.Sort, 
            request.Page, 
            limit
        );
    }
}
