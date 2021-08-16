using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        private readonly ILogger<CustomActionFilter> logger;

        public CustomActionFilter(ILogger<CustomActionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("ActionFilter.OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("ActionFilter.OnActionExecuted");

            context.HttpContext.Response.Body = new StreamLogger(context.HttpContext.Response.Body, content =>
            {
                logger.LogInformation(content);
            });
        }
    }
}