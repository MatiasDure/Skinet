using Application.Products;
using Infrastructure.Data;
using Infrastructure.Data.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}