using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<WeatherForecast> GetFromServices([FromServices] ILogger<WeatherForecastController> logger)
        {
            logger.LogError("Error");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<WeatherForecast> GetFromContext()
        {
            var logger = (ILogger<WeatherForecastController>)HttpContext.RequestServices.GetService(typeof(ILogger<WeatherForecastController>));

            logger.LogError("GetFromContext");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("[action]")]
        public string GetString([FromQuery] InputParameters prop)
        {
            return "Hello from Action";
        }

        [HttpPost]
        [Route("[action]")]
        public string PostData([FromBody] PostParameter[] prop, [FromHeader] int IntProperty)
        {
            return "Hello from Action";
        }

        [HttpGet]
        [Route("[action]/{id}")]
        //[Produces("application/json")]
        public ActionResult<OutputParameter> GetData(int id)
        {
            if (id == 10)
            {
                return NotFound();
            }

            return new OutputParameter
            {
                Id = 5,
                Name = "Cate",
                MyCaltegory = new Caltegory
                {
                    Id = 10,
                    CategoryName = "Teacher"
                }
            };
        }
    }
}