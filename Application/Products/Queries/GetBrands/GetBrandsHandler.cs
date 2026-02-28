using System;

namespace Application.Products.Queries.GetBrands;

public class GetBrandsHandler
{
    private readonly IProductRepository _productsRepo;

    public GetBrandsHandler(IProductRepository productsRepo)
    {
        _productsRepo = productsRepo;
    }
}
