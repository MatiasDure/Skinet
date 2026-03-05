using MediatR;

namespace Application.Products.Queries.GetTypes;

public record GetTypesQuery : IRequest<IReadOnlyList<string>>;
