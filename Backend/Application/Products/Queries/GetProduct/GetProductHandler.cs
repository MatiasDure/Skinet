using System;
using Application.Urls;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Queries.GetProduct;

public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDto?>
{
    private readonly IRepository<Product> _productsRepo;
    private readonly IUrlBuilder _urlBuilder;

    public GetProductHandler(IRepository<Product> productsRepo, IUrlBuilder urlBuilder)
    {
        _productsRepo = productsRepo;
        _urlBuilder = urlBuilder;
    }

    public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productsRepo.GetEntityByIdAsync(request.Id);
        if(product == null) return null;

        var absoluteUrl = _urlBuilder.BuildImageUrl(product.PictureUrl);
        
        return new ProductDto(
            Id: product.Id,
            Name: product.Name,
            Description: product.Description,
            Price: product.Price,
            PictureUrl: absoluteUrl,
            Type: product.Type,
            Brand: product.Brand,
            QuantityInStock: product.QuantityInStock
        );
    }
}
