using System.ComponentModel;

namespace Application.Products.Queries.ListProducts;

public record ProductSpecParams(
    List<string> Brands, 
    List<string> Types, 
    string? Sort,
    int Page,
    int Limit 
);
