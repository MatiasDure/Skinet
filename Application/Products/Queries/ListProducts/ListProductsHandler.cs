using System;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Queries.ListProducts;

public class ListProductsHandler : IRequestHandler<ListProductsQuery, IReadOnlyList<ProductDto>>
{
    private readonly IRepository<Product> _productsRepo;

    public ListProductsHandler(IRepository<Product> productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<IReadOnlyList<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepo.GetListWithSpecAsync(new ProductsSpecification(request.Filter));

        return products
            .Select(p => new ProductDto(p))
            .ToList();
    }
}
