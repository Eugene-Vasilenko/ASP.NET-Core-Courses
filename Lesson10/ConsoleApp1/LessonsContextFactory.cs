using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConsoleApp1
{
    public class LessonsContextFactory : IDesignTimeDbContextFactory<LessonsDbContext>
    {
        public LessonsDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");

            var configuration = configurationBuilder.Build();

            var connectionString = configuration.GetConnectionString("LessonsConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<LessonsDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new LessonsDbContext(optionsBuilder.Options);
        }
    }
}