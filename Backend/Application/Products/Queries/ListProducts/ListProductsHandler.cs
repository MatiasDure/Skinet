using System;
using Application.Urls;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Queries.ListProducts;

public class ListProductsHandler : IRequestHandler<ListProductsQuery, PaginationDto<ProductDto>>
{
    private readonly IRepository<Product> _productsRepo;
    private readonly IUrlBuilder _urlBuilder;

    public ListProductsHandler(IRepository<Product> productsRepo, IUrlBuilder urlBuilder)
    {
        _productsRepo = productsRepo;
        _urlBuilder = urlBuilder;
    }

    public async Task<PaginationDto<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var specification = new ProductsSpecification(request.SpecParams);
        
        var products = await _productsRepo.GetListWithSpecAsync(specification);
        var count = await _productsRepo.CountAsync(specification);

        return new PaginationDto<ProductDto> (
            request.SpecParams.Page,
            request.SpecParams.Limit,
            count,
            products
                .Select(p => new ProductDto(
                    Id: p.Id,
                    Name: p.Name,
                    Description: p.Description,
                    Price: p.Price,
                    PictureUrl: _urlBuilder.BuildImageUrl(p.PictureUrl),
                    Type: p.Type,
                    Brand: p.Brand,
                    QuantityInStock: p.QuantityInStock
                ))
                .ToList()
        );
    }
}
