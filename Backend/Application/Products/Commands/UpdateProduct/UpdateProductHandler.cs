using System;
using Application.Urls;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto?>
{
    private readonly IRepository<Product> _productsRepo;
    private readonly IUrlBuilder _urlBuilder;

    public UpdateProductHandler(IRepository<Product> productsRepo, IUrlBuilder urlBuilder)
    {
        _productsRepo = productsRepo;
        _urlBuilder = urlBuilder;
    }

    public async Task<ProductDto?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsRepo.GetEntityByIdAsync(request.Id);

        if(product == null) return null;

        product.Update(
            request.Name, 
            request.Description, 
            request.Price, 
            request.PictureUrl, 
            request.Type, 
            request.Brand, 
            request.QuantityInStock
        );

        await _productsRepo.SaveChangesAsync();

        return new ProductDto(
            Id: product.Id,
            Name: product.Name,
            Description: product.Description,
            Price: product.Price,
            PictureUrl: _urlBuilder.BuildImageUrl(product.PictureUrl),
            Type: product.Type,
            Brand: product.Brand,
            QuantityInStock: product.QuantityInStock
        );
    }
}
