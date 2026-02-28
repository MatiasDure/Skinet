using MediatR;

namespace Application.Products.Queries.GetBrands;

public record GetBrandsQuery() : IRequest<IReadOnlyList<string>>;
