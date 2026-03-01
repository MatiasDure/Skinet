using MediatR;

namespace Application.Products.Queries.ListProducts;

public record ListProductsQuery(ProductSpecParams Filter) : IRequest<IReadOnlyList<ProductDto>>;
