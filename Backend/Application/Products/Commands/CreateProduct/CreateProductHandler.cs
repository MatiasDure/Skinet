using System;
using Application.Urls;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IRepository<Product> _productsRepo;
    private readonly IUrlBuilder _urlBuilder;

    public CreateProductHandler(IRepository<Product> productsRepo, IUrlBuilder urlBuilder)
    {
        _productsRepo = productsRepo;
        _urlBuilder = urlBuilder;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productCreated = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            PictureUrl = request.PictureUrl,
            Type = request.Type,
            Brand = request.Brand,
            QuantityInStock = request.QuantityInStock
        };
        
        _productsRepo.AddEntity(productCreated);
        await _productsRepo.SaveChangesAsync();

        return new ProductDto(
            Id: productCreated.Id,
            Name: productCreated.Name,
            Description: productCreated.Description,
            Price: productCreated.Price,
            PictureUrl: _urlBuilder.BuildImageUrl(productCreated.PictureUrl),
            Type: productCreated.Type,
            Brand: productCreated.Brand,
            QuantityInStock: productCreated.QuantityInStock
        );
    }
}
