using ApiNET.Middleware;
using Microsoft.AspNetCore.Builder;

namespace ApiNET.Extension
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseIPFilter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IPFilterMiddleware>();
        }
    }
}