using Microsoft.AspNetCore.Builder;

namespace WebApplication1
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder applicationBuilder, string requiredHeder)
        {
            return applicationBuilder.UseMiddleware<CustomMiddleware>(requiredHeder);
        }
    }
}