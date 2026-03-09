using System;

namespace API.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection AddApiCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("Skinet", p =>
            {
                p.AllowAnyHeader();
                p.AllowAnyMethod();
                p.AllowAnyOrigin(); // TODO: Update to specific frontned origin
            });
        });

        return services;
    }
}
