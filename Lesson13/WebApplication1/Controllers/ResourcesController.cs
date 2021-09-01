using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly LessonsDbContext _dbContext;

        public ResourcesController(LessonsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = "Test Role only")]
        public IActionResult GetStudents()
        {
            var students = _dbContext.Students
                .Include(i => i.Roles)
                .ToList();

            return new ObjectResult(students);
        }
    }
}
