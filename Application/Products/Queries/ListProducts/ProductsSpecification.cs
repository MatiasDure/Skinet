using System;
using Core.Products.Entities;
using Core.Specifications;

namespace Application.Products.Queries.ListProducts;

public class ProductsSpecification : BaseSpecification<Product>
{
    public ProductsSpecification(ProductSpecParams specParams)
    {
        Criteria = p => 
            (specParams.Brands.Count == 0 || specParams.Brands.Contains(p.Brand)) && 
            (specParams.Types.Count == 0 || specParams.Types.Contains(p.Type));

        if (specParams.Sort == "priceAsc")
            OrderBy = p => p.Price;
        else if (specParams.Sort == "priceDesc")
            OrderByDescending = p => p.Price;
        else 
            OrderBy = p => p.Name;
    }
}
