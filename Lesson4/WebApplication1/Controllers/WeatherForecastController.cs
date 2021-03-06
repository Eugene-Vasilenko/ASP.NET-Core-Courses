using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration configuration;
        private readonly IOptions<MyLibraryConfig> myLibraryConfig;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IConfiguration configuration, IOptions<MyLibraryConfig> myLibraryConfig)
        {
            _logger = logger;
            this.configuration = configuration;
            this.myLibraryConfig = myLibraryConfig;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var key = configuration["key6"];

        //    if (int.TryParse(key, out int keyResult))
        //    {
        //        var rng = new Random();
        //        return Enumerable.Range(1, keyResult)
        //            .Select(index => new WeatherForecast
        //            {
        //                Date = DateTime.Now.AddDays(index),
        //                TemperatureC = rng.Next(-20, 55),
        //                Summary = Summaries[rng.Next(Summaries.Length)]
        //            })
        //            .ToArray();
        //    }

        //    throw new Exception("Configuration value 'key1' not set");
        //}

        [HttpGet]
        public string GetConfiguration()
        {
            return JsonSerializer.Serialize(this.myLibraryConfig);
        }
    }
}