using System;
using System.Runtime.CompilerServices;
using Core.Products.Entities;
using MediatR;

namespace Application.Products.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IRepository<Product> _productsRepo;

    public DeleteProductHandler(IRepository<Product> productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsRepo.GetEntityByIdAsync(request.Id);

        if(product == null) return;

        _productsRepo.DeleteEntity(product);
        await _productsRepo.SaveChangesAsync();

        return;
    }
}
