using ConsoleApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly LessonsDbContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, LessonsDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _dbContext.Students.ToArray();
        }

        [HttpPost]
        public ActionResult<dtoStudent> Add([FromBody] dtoStudent student)
        {
            //if (!_dbContext.Rooms.Any(i => i.Id == student.RoomId))
            //{
            //    ModelState.AddModelError("RoomId", "The room with Id: " + student.RoomId + " does not exist.");
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ent = new Student();

            student.Map(ent);

            //_dbContext.Students.Add(ent);
            //_dbContext.SaveChanges();

            student.Id = ent.Id;

            return student;

        }
    }
}
