using System;
using MediatR;

namespace Application.Products.Queries.GetTypes;

public class GetTypesHandler : IRequestHandler<GetTypesQuery, IReadOnlyList<string>>
{
    private readonly IProductRepository _productsRepo;

    public GetTypesHandler(IProductRepository productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<IReadOnlyList<string>> Handle(GetTypesQuery request, CancellationToken cancellationToken) => await _productsRepo.GetTypesAsync();
}
