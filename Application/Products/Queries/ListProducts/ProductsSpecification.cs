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
    }
}
