using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }

        public StudentProfile Profile { get; set; }

        public int? RoomId { get; set; }
        public Room Room { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}