using System;
using System.Data;

namespace Core.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public required string Type { get; set; }
    public required string Brand { get; set; }
    public int QuantityInStock { get; set; }

    public void Update(Product updatedProduct)
    {
        Name = updatedProduct.Name;
        Description = updatedProduct.Description;
        Price = updatedProduct.Price;
        PictureUrl = updatedProduct.PictureUrl;
        Type = updatedProduct.Type;
        Brand = updatedProduct.Brand;
        QuantityInStock = updatedProduct.QuantityInStock;
    }
}
