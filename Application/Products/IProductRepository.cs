using Core.Products.Entities;

namespace Application.Products
{
    public interface IProductRepository
    {
        public Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type);
        public Task<Product?> GetProductByIdAsync(int id);
        public void AddProduct(Product product);
        public void DeleteProduct(Product product);
        public Task<IReadOnlyList<string>> GetBrandsAsync();
        public Task<IReadOnlyList<string>> GetTypesAsync();
        public Task<bool> SaveChangesAsync();
    }
}