using System;
using Core.Products.Entities;
using Core.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Products;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        this._context = context;
    }

    public void AddProduct(Product product) => _context.Products.Add(product);

    public void DeleteProduct(Product product) => _context.Products.Remove(product);

    public async Task<Product?> GetProductByIdAsync(int id) => await _context.Products.FindAsync(id);

    public async Task<IReadOnlyList<Product>> GetProductsAsync() => await _context.Products.ToListAsync();

    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}
