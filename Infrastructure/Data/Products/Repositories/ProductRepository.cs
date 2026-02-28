using System;
using System.Threading.Tasks;
using Application.Products;
using Core.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Products;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product) => _context.Products.Add(product);

    public void DeleteProduct(Product product) => _context.Products.Remove(product);

    public async Task<IReadOnlyList<string>> GetBrandsAsync() => await _context.Products.Select(p => p.Brand).Distinct().ToListAsync();

    public async Task<Product?> GetProductByIdAsync(int id) => await _context.Products.FindAsync(id);

    public async Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type)
    {
        var query = _context.Products.AsQueryable();

        if(!string.IsNullOrEmpty(brand))
            query = query.Where(p => p.Brand == brand);
        if(!string.IsNullOrEmpty(type))
            query = query.Where(p => p.Type == type);

        return await query.ToListAsync();
    } 

    public async Task<IReadOnlyList<string>> GetTypesAsync() => await _context.Products.Select(p => p.Type).Distinct().ToListAsync();

    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}
