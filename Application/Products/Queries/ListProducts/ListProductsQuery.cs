using MediatR;

namespace Application.Products.Queries.ListProducts;

public record ListProductsQuery(
    string? Brand,
    string? Type
) : IRequest<IReadOnlyList<ProductDto>>;
