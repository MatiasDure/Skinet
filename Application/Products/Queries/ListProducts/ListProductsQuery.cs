using MediatR;

namespace Application.Products.Queries.ListProducts;

public record ListProductsQuery(
    string? Brand,
    string? Type,
    string? Sort
) : IRequest<IReadOnlyList<ProductDto>>;
