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
)
{
    public ProductDto(Product product) : this(
        Id: product.Id,
        Name: product.Name,
        Description: product.Description,
        Price: product.Price,
        PictureUrl: product.PictureUrl,
        Type: product.Type,
        Brand: product.Brand,
        QuantityInStock: product.QuantityInStock
    ) {}
};

