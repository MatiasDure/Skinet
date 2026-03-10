using System;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Queries.GetFilters;

public class GetFiltersHandler : IRequestHandler<GetFiltersQuery, IReadOnlyList<ProductFilterDto>>
{
    private readonly IRepository<Product> _productsRepo;

    public GetFiltersHandler(IRepository<Product> productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<IReadOnlyList<ProductFilterDto>> Handle(
        GetFiltersQuery request, 
        CancellationToken cancellationToken)
    {
        var brands = await _productsRepo.SelectAsync(p => 
            p.Select(x => x.Brand)
            .Distinct()
            .OrderBy(x => x));
        
        var types = await _productsRepo.SelectAsync(p => 
            p.Select(x => x.Type)
            .Distinct()
            .OrderBy(x => x));

        var filters = new List<ProductFilterDto>
        {
            new ProductFilterDto("Brands", brands),
            new ProductFilterDto("Types", types)
        };

        return filters;
    }
}
