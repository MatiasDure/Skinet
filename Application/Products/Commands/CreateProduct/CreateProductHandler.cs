using System;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productsRepo;

    public CreateProductHandler(IProductRepository productsRepo)
    {
        _productsRepo = productsRepo;
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
        
        _productsRepo.AddProduct(productCreated);
        await _productsRepo.SaveChangesAsync();

        return new ProductDto(productCreated);
    }
}
