using System;
using Application.Urls;

namespace API.Urls;

public class UrlBuilder : IUrlBuilder
{
    private readonly IHttpContextAccessor _http;

    public UrlBuilder(IHttpContextAccessor http)
    {
        _http = http;
    }

    public string BuildImageUrl(string relativePath)
    {
        var request = _http.HttpContext!.Request;
        return $"{request.Scheme}://{request.Host}{relativePath}";
    }
}
