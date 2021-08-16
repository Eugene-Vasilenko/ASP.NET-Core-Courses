using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace WebApplication1
{
    public class CustomResultFilter : Attribute, IResultFilter
    {
        private readonly ILogger<CustomResultFilter> _logger;

        public CustomResultFilter(ILogger<CustomResultFilter> logger)
        {
            _logger = logger;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("CustomResultFilter.OnResultExecuting");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("CustomResultFilter.OnResultExecuted");
        }
    }
}