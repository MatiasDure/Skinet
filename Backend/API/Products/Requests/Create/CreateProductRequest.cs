namespace API.Products.Requests.Create;

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    string PictureUrl,
    string Type,
    string Brand,
    int QuantityInStock
);
