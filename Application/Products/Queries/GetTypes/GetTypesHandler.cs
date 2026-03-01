using System;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Queries.GetTypes;

public class GetTypesHandler : IRequestHandler<GetTypesQuery, IReadOnlyList<string>>
{
    private readonly IRepository<Product> _productsRepo;

    public GetTypesHandler(IRepository<Product> productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<IReadOnlyList<string>> Handle(GetTypesQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepo.GetListAsync();

        return products
            .Select(p => p.Type)
            .Distinct()
            .OrderBy(t => t)
            .ToList();
    } 
}
