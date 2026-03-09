using System;

namespace Application.Urls;

public interface IUrlBuilder
{
    string BuildImageUrl(string relativePath);
}
