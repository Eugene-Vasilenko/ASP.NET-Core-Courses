using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleApp1
{
    public class LessonsContextFactory : IDesignTimeDbContextFactory<LessonsDbContext>
    {
        public LessonsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LessonsDbContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Lessons;Integrated Security=True;");

            return new LessonsDbContext(optionsBuilder.Options);
        }
    }
}