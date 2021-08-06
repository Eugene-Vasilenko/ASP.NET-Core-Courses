using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly string _requiredHeder;

        public CustomMiddleware(RequestDelegate requestDelegate, string requiredHeder)
        {
            _requestDelegate = requestDelegate;
            _requiredHeder = requiredHeder;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("TestHeared"))
            {
                await context.Response.WriteAsync("'TestHeared' does not exist");
                return;
            }

            var headerValue = context.Request.Headers["TestHeared"];

            if (headerValue == _requiredHeder)
            {
                await _requestDelegate.Invoke(context);
            }
            else
            {
                await context.Response.WriteAsync("'TestHeared' does not valid");
            }
        }
    }
}