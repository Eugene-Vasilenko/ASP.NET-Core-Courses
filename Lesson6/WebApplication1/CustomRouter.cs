using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class CustomRouter : IRouter
    {
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new NotImplementedException();
        }

        public async Task RouteAsync(RouteContext context)
        {
            var pathValue = context.HttpContext.Request.Path.Value;

            if (string.Equals(pathValue, "/home/index"))
            {
                context.Handler = async ctx =>
                {
                    await ctx.Response.WriteAsync("'/home/index' is depricated. Do not use it");
                };
            }

            await Task.CompletedTask;
        }
    }
}