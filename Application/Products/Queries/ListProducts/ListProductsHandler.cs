using System;
using MediatR;

namespace Application.Products.Queries.ListProducts;

public class ListProductsHandler : IRequestHandler<ListProductsQuery, IReadOnlyList<ProductDto>>
{
    private readonly IProductRepository _productsRepo;

    public ListProductsHandler(IProductRepository productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<IReadOnlyList<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepo.GetProductsAsync(request.Brand, request.Type, request.Sort);
        return products
            .Select(p => new ProductDto(p))
            .ToList();
    }
}
