using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace McKabue.Extentions.Utility
{
    public static class HttpContextExtentions
    {
        public static bool IsAuthenticated(this HttpContext _httpContext)
        {
            return _httpContext?.User != null &&
                (_httpContext?.User?.Identities?.Any(i => i.IsAuthenticated) ?? false);
        }
        public static string AbsolutePath(this HttpContext _httpContext)
        {
            return _httpContext != null ?
                UrlCombineLib.UrlCombine.Combine(_httpContext?.BasePath(), _httpContext?.RelativePath()) :
                string.Empty;
        }
        public static string RelativePath(this HttpContext _httpContext)
        {
            return _httpContext?.Request != null ?
                UriHelper.GetEncodedPathAndQuery(_httpContext?.Request) :
                string.Empty;
        }
        public static string BasePath(this HttpContext _httpContext)
        {
            return _httpContext != null ?
                $"{_httpContext?.Request?.Scheme}://{_httpContext?.Request?.Host.Value}" :
                string.Empty;
        }
        public static bool IsLocalhost(this HttpContext _httpContext)
        {
            string host = _httpContext?.Request?.Host.Host.Trim();
            string ip = _httpContext?.IpAddress();
            return string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(ip, "::1", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(ip, "127.0.0.1", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(ip, "127.0.0.0", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(ip, "0.0.0.0", StringComparison.OrdinalIgnoreCase);
        }
        public static string Referrer(this HttpContext _httpContext)
        {
            return _httpContext.Request.Headers["Referer"].ToString();
        }
        public static string UserAgent(this HttpContext _httpContext)
        {
            return _httpContext.Request.Headers["User-Agent"].ToString();
        }
        public static string IpAddress(this HttpContext _httpContext)
        {
            return _httpContext?.Connection?.RemoteIpAddress.ToString();
        }
        public static bool IsAjax(this HttpContext _httpContext)
        {
            return _httpContext?.Request?.Headers["X-Requested-With"].ToString() == "XMLHttpRequest";
        }
    }
}