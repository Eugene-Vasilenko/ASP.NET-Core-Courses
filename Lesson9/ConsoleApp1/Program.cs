using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

//Scaffold-DbContext "Data Source=.;Initial Catalog=DatabaseName;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

namespace ConsoleApp1
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");

            var configuration = configurationBuilder.Build();

            var connectionString = configuration.GetConnectionString("LessonsConnectionString");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<LessonsDbContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            dbContextOptionsBuilder.LogTo(Console.WriteLine);

            //using (var dbContext = new LessonsDbContext(dbContextOptionsBuilder.Options))
            //{
            //    var tommy = new Student
            //    {
            //        Name = "Tommy",
            //        Grade = "Masters",
            //    };

            //    var cate = new Student
            //    {
            //        Name = "Cate",
            //        Grade = "Masters",
            //    };

            //    dbContext.Students.AddRange(tommy, cate);

            //    var cateProfile = new StudentProfile
            //    {
            //        Age = 20,
            //        Sex = "Girl",
            //        StudentRecord = cate
            //    };

            //    dbContext.StudentProfiles.Add(cateProfile);

            //    dbContext.SaveChanges();
            //}

            //using (var dbContext = new LessonsDbContext(dbContextOptionsBuilder.Options))
            //{
            //    var tommy = await dbContext.Students.SingleAsync(i => i.Name == "Tommy");

            //    var cate = await dbContext.Students.SingleAsync(i => i.Name == "Cate");

            //    var room = new Room
            //    {
            //        Name = "Class room",
            //        Floor = 2,
            //        Students = new List<Student> { tommy, cate }
            //    };

            //    dbContext.Rooms.Add(room);

            //    dbContext.SaveChanges();
            //}

            //using (var dbContext = new LessonsDbContext(dbContextOptionsBuilder.Options))
            //{
            //    var tommy = await dbContext.Students.SingleAsync(i => i.Name == "Tommy");

            //    var cate = await dbContext.Students.SingleAsync(i => i.Name == "Cate");

            //    var teacher = new Teacher
            //    {
            //        Name = "Jerry",
            //        Students = new List<Student> { tommy, cate }
            //    };

            //    dbContext.Teachers.Add(teacher);

            //    dbContext.SaveChanges();
            //}

            using (var dbContext = new LessonsDbContext(dbContextOptionsBuilder.Options))
            {
                var tommy = await dbContext.Students.SingleAsync(i => i.Name == "Tommy");

                //Оновлення
                tommy.Grade = "Doctor";

                var cate = await dbContext.Students.SingleAsync(i => i.Name == "Cate");

                //Видалення
                dbContext.Students.Remove(cate);

                dbContext.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}