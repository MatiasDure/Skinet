namespace API.Products.Requests;

public record ProductParamsRequest(
    string? Brands, 
    string? Types, 
    string? Sort,
    int Page = 1,
    int Limit = 10
);
