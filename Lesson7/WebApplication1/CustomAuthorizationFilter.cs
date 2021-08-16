using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string headerName;

        public CustomAuthorizationFilter(string headerName)
        {
            this.headerName = headerName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("OnAuthorization");

            if (!context.HttpContext.Request.Headers.ContainsKey(headerName))
            {
                context.Result = new ContentResult { Content = "You cant use this URL." };
            }
        }
    }
}