using System.ComponentModel;

namespace Application.Products.Queries.ListProducts;

public record ProductSpecParams(
    List<string> Brands, 
    List<string> Types, 
    string? Sort,
    string? Search,
    int Page,
    int Limit 
);
