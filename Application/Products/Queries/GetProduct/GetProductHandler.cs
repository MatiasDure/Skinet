using System;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Queries.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDto?>
{
    private readonly IRepository<Product> _productsRepo;

    public GetProductHandler(IRepository<Product> productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productsRepo.GetEntityByIdAsync(request.Id);
        return product == null ? null : new ProductDto(product);
    }
}
