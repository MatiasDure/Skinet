using System;
using Core.Products.Entities;
using Core.Specifications;

namespace Application.Products.Queries.ListProducts;

public class ProductForCountSpecification: BaseSpecification<Product>
{
    public ProductForCountSpecification(ProductSpecParams specParams)
    {
        Criteria = p => 
            (specParams.Brands.Count == 0 || specParams.Brands.Contains(p.Brand)) && 
            (specParams.Types.Count == 0 || specParams.Types.Contains(p.Type));
    }
}
