using System;
using MediatR;

namespace Application.Products.Queries.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDto?>
{
    private readonly IProductRepository _productsRepo;

    public GetProductHandler(IProductRepository productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productsRepo.GetProductByIdAsync(request.Id);
        return product == null ? null : new ProductDto(product);
    }
}
