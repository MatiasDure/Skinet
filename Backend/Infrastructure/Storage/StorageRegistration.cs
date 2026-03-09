using System;
using Core.Storage;
using Infrastructure.Storage.Local;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Storage;

public static class StorageRegistration
{
    public static IServiceCollection AddLocalImageStorage(
        this IServiceCollection services,
        string rootPath,
        string publicPath
    )
    {
        services.AddSingleton(new LocalStorageOptions(rootPath, publicPath));
        services.AddScoped<IImageStorage, LocalImageStorage>();
        
        return services;
    }
}
