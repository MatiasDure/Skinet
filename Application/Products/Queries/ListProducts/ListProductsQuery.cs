using MediatR;

namespace Application.Products.Queries.ListProducts;

public record ListProductsQuery() : IRequest<IReadOnlyList<ProductDto>>;
