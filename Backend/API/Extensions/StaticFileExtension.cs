using System;
using Core.Storage;
using Infrastructure.Storage.Local;
using Microsoft.Extensions.FileProviders;

namespace API.Extensions;

public static class StaticFileExtension
{
    public static IApplicationBuilder UseImageStorage(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var storage = scope.ServiceProvider.GetRequiredService<IImageStorage>();

        if(storage is LocalImageStorage local)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
               FileProvider = new PhysicalFileProvider(local.PhyisicalPath),
               RequestPath = local.RequestPath 
            });
        }

        return app;
    }
}
