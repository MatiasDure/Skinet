using System;
using MediatR;

namespace Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto?>
{
    private readonly IProductRepository _productsRepo;

    public UpdateProductHandler(IProductRepository productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<ProductDto?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productsRepo.GetProductByIdAsync(request.Id);

        if(product == null) return null;

        product.Update(
            request.Name, 
            request.Description, 
            request.Price, 
            request.PictureUrl, 
            request.Type, 
            request.Brand, 
            request.QuantityInStock
        );

        await _productsRepo.SaveChangesAsync();

        return new ProductDto(product);
    }
}
