using System;
using System.Runtime.CompilerServices;
using MediatR;

namespace Application.Products.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productsRepo;

    public DeleteProductHandler(IProductRepository productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsRepo.GetProductByIdAsync(request.Id);

        if(product == null) return;

        _productsRepo.DeleteProduct(product);
        await _productsRepo.SaveChangesAsync();

        return;
    }
}
