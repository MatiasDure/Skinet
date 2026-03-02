using System;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Queries.ListProducts;

public class ListProductsHandler : IRequestHandler<ListProductsQuery, PaginationDto<ProductDto>>
{
    private readonly IRepository<Product> _productsRepo;

    public ListProductsHandler(IRepository<Product> productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<PaginationDto<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepo.GetListWithSpecAsync(new ProductsSpecification(request.SpecParams));
        var count = await _productsRepo.CountAsync(new ProductForCountSpecification(request.SpecParams));

        return new PaginationDto<ProductDto> (
            request.SpecParams.Page,
            request.SpecParams.Limit,
            count,
            products
                .Select(p => new ProductDto(p))
                .ToList()
        );
    }
}
