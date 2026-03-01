using System;
using Core.Products.Entities;
using Core.Specifications;

namespace Application.Products.Queries.ListProducts;

public class ProductsSpecification : BaseSpecification<Product>
{
    public ProductsSpecification(ProductSpecParams filter)
    {
        Criteria = p => 
            (string.IsNullOrEmpty(filter.Brand) || p.Brand == filter.Brand) && 
            (string.IsNullOrEmpty(filter.Type) || p.Type == filter.Type);

        if (filter.Sort == "priceAsc")
            OrderBy = p => p.Price;
        else if (filter.Sort == "priceDesc")
            OrderByDescending = p => p.Price;
    }
}
