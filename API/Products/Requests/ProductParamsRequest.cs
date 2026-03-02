namespace API.Products.Requests;

public record ProductParamsRequest(
    string? Brands, 
    string? Types, 
    string? Sort,
    string? Search,
    int Page = 1,
    int Limit = 10
);
