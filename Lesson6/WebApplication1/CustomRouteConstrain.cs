using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebApplication1
{
    public class CustomRouteConstrain : IRouteConstraint
    {
        private readonly string mathingString;

        public CustomRouteConstrain(string mathingString)
        {
            this.mathingString = mathingString;
        }

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            var value = (string)values[routeKey];

            return value == mathingString;
        }
    }
}