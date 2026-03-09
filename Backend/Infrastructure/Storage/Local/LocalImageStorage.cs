using System;
using Core.Storage;

namespace Infrastructure.Storage.Local;

public class LocalImageStorage : IImageStorage
{
    private readonly string _rootPath;
    private readonly string _publicPath;
    public string PhyisicalPath => _rootPath;
    public string RequestPath => _publicPath;

    public LocalImageStorage(LocalStorageOptions options)
    {
        _rootPath = options.RootPath;
        _publicPath = options.PublicPath;

        if(!Directory.Exists(_rootPath))
            Directory.CreateDirectory(_rootPath);
    }

    public Task<Stream?> GetAsync(string fileName)
    {
        var path = Path.Combine(_rootPath, fileName);

        if(!File.Exists(path))
            return Task.FromResult<Stream?>(null);

        return Task.FromResult<Stream?>(File.OpenRead(path));
    }

    public string GetPublicUrl(string fileName) => $"{_publicPath}/{fileName}";

    public async Task SaveAsync(string fileName, Stream content)
    {
        var path = Path.Combine(_rootPath, fileName);
        using var fileStream = File.Create(path);
        await content.CopyToAsync(fileStream);
    }
}
