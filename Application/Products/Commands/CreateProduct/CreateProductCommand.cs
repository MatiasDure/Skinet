using MediatR;

namespace Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    string PictureUrl,
    string Type,
    string Brand,
    int QuantityInStock
) : IRequest<ProductDto>;
