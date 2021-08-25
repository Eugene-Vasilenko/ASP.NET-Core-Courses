using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}