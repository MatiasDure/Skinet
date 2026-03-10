using MediatR;

namespace Application.Products.Queries.GetFilters;

public record GetFiltersQuery() : IRequest<IReadOnlyList<ProductFilterDto>>;
