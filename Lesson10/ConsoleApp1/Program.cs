using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            //dbContextOptionsBuilder.LogTo(Console.WriteLine);

            using (var dbContext = new LessonsDbContext(dbContextOptionsBuilder.Options))
            {
                //var studentsWithFloor = from student in dbContext.Students
                //                        join room in dbContext.Rooms on student.RoomId equals room.Id
                //                        select
                //                        new
                //                        {
                //                            student.Id,
                //                            student.Name,
                //                            room.Floor
                //                        };

                //var students = dbContext.Students;

                //var students2 = students.Select(i => new { i.Id, i.Name, i.Room.Floor });

                //foreach (var item in studentsWithFloor)
                //{
                //    Console.WriteLine($"Name: {item.Name}, Floor: {item.Floor}");
                //}

                //var student = dbContext.Students
                //    .Include(i => i.Room)
                //    .OrderBy(i => i.Name)
                //    .ThenByDescending(i => i.RoomId)
                //    .LastOrDefault(i => i.Id == 1003);

                //Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");

                //dbContext.Rooms.Load();

                //var luck = dbContext.Students.AsNoTracking().Single(i => i.Name == "Luck");

                //var students = dbContext.Students.ToList();

                var students2 = dbContext.Students.Select(i => new test(i.Id, i.Name, i.Room.Floor))
                    .ToList();

                foreach (var item in students2)
                {
                    Console.WriteLine($"Name: {item.Name}, Floor: {item.Floor}");
                }

                string nameFilter = "Lu";
                string gradeFilter = string.Empty;

                IQueryable<Student> list = dbContext.Students;

                if (!string.IsNullOrEmpty(nameFilter))
                {
                    list = list.Where(i => i.Name.Contains(nameFilter));
                }

                if (!string.IsNullOrEmpty(gradeFilter))
                {
                    list = list.Where(i => EF.Functions.Like(i.RoomId.ToString(), ""));
                }

                //wrong filtering
                IQueryable<Student> wrongList = dbContext.Students
                 .Where(i => nameFilter == null && nameFilter == "" || i.Name.Contains(nameFilter))
                 .Where(i => gradeFilter == null && gradeFilter == "" || i.Name.Contains(gradeFilter));

                list.AsQueryable();
            }

            Console.ReadLine();
        }
    }

    public class test
    {
        public test(int id, string name, int floor)
        {
            Id = id;
            Name = name;
            Floor = floor;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
    }
}