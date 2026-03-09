using Core.Products.Entities;

namespace Application.Products;

public record ProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    string PictureUrl,
    string Type,
    string Brand,
    int QuantityInStock
);

