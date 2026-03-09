using System;

namespace Core.Storage;

public interface IImageStorage
{
    string GetPublicUrl(string fileName);
    Task SaveAsync(string fileName, Stream content);
    Task<Stream?> GetAsync(string fileName);
}
