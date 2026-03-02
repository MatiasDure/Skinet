using MediatR;

namespace Application.Products.Queries.ListProducts;

public record ListProductsQuery(ProductSpecParams SpecParams) : IRequest<PaginationDto<ProductDto>>;
