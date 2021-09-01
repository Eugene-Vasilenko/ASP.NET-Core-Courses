using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
