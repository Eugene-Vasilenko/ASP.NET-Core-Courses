using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        private readonly ILogger<CustomResourceFilter> _logger;

        public CustomResourceFilter(ILogger<CustomResourceFilter> logger)
        {
            _logger = logger;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _logger.LogInformation("OnResourceExecuting");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _logger.LogInformation("OnResourceExecuted");
        }
    }
}