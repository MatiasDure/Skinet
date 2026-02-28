using System;
using Core.Entities;

namespace Core.Products.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string PictureUrl { get; set; }
        public required string Type { get; set; } // This should ideally be its own Entity
        public required string Brand { get; set; } // This should ideally be its own Entity
        public int QuantityInStock { get; set; }

        public void Update(
            string name,
            string description,
            decimal price,
            string pictureUrl,
            string type,
            string brand,
            int quantityInStock
        )
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
            Type = type;
            Brand = brand;
            QuantityInStock = quantityInStock;
        }
    }
}