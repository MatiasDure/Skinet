namespace API.Products.Requests;

public record UpdateProductRequest(
    string Name,
    string Description,
    decimal Price,
    string PictureUrl,
    string Type,
    string Brand,
    int QuantityInStock
);
