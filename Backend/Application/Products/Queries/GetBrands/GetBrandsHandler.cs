using System;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Queries.GetBrands;

public class GetBrandsHandler : IRequestHandler<GetBrandsQuery, IReadOnlyList<string>>
{
    private readonly IRepository<Product> _productsRepo;

    public GetBrandsHandler(IRepository<Product> productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<IReadOnlyList<string>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepo.GetListAsync();

        return products
            .Select(p => p.Brand)
            .Distinct()
            .OrderBy(t => t)
            .ToList();
    } 
}
