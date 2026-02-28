using System;
using MediatR;

namespace Application.Products.Queries.GetBrands;

public class GetBrandsHandler : IRequestHandler<GetBrandsQuery, IReadOnlyList<string>>
{
    private readonly IProductRepository _productsRepo;

    public GetBrandsHandler(IProductRepository productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<IReadOnlyList<string>> Handle(GetBrandsQuery request, CancellationToken cancellationToken) => await _productsRepo.GetBrandsAsync();
}
