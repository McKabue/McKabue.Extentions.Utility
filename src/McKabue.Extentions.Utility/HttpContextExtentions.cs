using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Primitives;

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
            string ip = _httpContext?.XForwardedFor_OR_IpAddress();
            return string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(ip, "::1", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(ip, "127.0.0.1", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(ip, "127.0.0.0", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(ip, "0.0.0.0", StringComparison.OrdinalIgnoreCase);
        }
        public static string Referrer(this HttpContext _httpContext)
        {
            return _httpContext?.Request?.GetTypedHeaders()?.Referer?.ToString();
        }
        public static string UserAgent(this HttpContext _httpContext)
        {
            StringValues? stringValues =
                _httpContext?.Request?.Headers?.FirstOrDefault(i => i.Key?.Trim()?.ToLowerInvariant() == "user-agent").Value;

            return stringValues?.Join(" ")?.Trim();
        }
        public static string IpAddress(this HttpContext httpContext)
        {
            return httpContext?.Connection?.RemoteIpAddress?.ToString();
        }
        /// <summary>
        /// IP Address of the client that made the first request.
        /// 
        /// https://support.cloudflare.com/hc/en-us/articles/200170986-How-does-Cloudflare-handle-HTTP-Request-headers-
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string XForwardedFor(this HttpContext httpContext)
        {
            string key = "X-Forwarded-For".ToLowerInvariant();
            return httpContext?.Request?.Headers?.Get(i => i.HasValue() && i?.Trim()?.ToLowerInvariant() == key);
        }
        public static string XForwardedFor_OR_IpAddress(this HttpContext httpContext)
        {
            string xForwardedFor = httpContext?.XForwardedFor();
            if (xForwardedFor.HasValue())
            {
                return xForwardedFor;
            }

            return httpContext?.IpAddress();
        }
        public static bool IsAjax(this HttpContext _httpContext)
        {
            return _httpContext?.Request?.Headers["X-Requested-With"].ToString() == "XMLHttpRequest";
        }

        public static string BrowserReferrer(this HttpContext _httpContext)
        {
            string xReferrer = _httpContext?.Request?.Headers?.Get("X-Referrer");
            if (xReferrer == null || xReferrer.IsEmpty())
            {
                return string.Empty;
            }

            return xReferrer;
        }
    }
}