using System;
using System.Text.Json;
using Core.Products.Entities;

namespace Infrastructure.Data.Seed;

public class DatabaseSeeder
{
    private readonly StoreContext _context;

    public DatabaseSeeder(StoreContext context)
    {
        _context = context;
    }
    
    public async Task SeedAsync()
    {
        if(!_context.Products.Any())
        {
            var json = await File.ReadAllTextAsync("../Infrastructure/Data/Seed/SeedData/products.json");
            var products = JsonSerializer.Deserialize<IReadOnlyList<Product>>(json) ?? [];
            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();
        }
    }
}
