using System;
using Core.Products.Entities;
using Core.Specifications;

namespace Application.Products.Queries.ListProducts;

public class ProductsSpecification : BaseSpecification<Product>
{
    public ProductsSpecification(ProductSpecParams specParams)
    {
        Criteria = p => 
            (string.IsNullOrEmpty(specParams.Search) || p.Name.ToLower().Contains(specParams.Search)) &&
            (specParams.Brands.Count == 0 || specParams.Brands.Contains(p.Brand)) && 
            (specParams.Types.Count == 0 || specParams.Types.Contains(p.Type));

        switch(specParams.Sort)
        {
            case "priceAsc":
                OrderBy = p => p.Price;
                break;
            case "priceDesc":
                OrderByDescending = p => p.Price;    
                break;
            default:
                OrderBy = p => p.Name;
                break;
        }

        // if page size = 10 and page index = 3, we skip the first 20 items (10 * (3 - 1) = 20) and get the next 10 items (20-29)
        ApplyPagination(specParams.Limit * (specParams.Page - 1), specParams.Limit);
    }
}
