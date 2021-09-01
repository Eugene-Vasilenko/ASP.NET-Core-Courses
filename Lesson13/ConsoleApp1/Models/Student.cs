using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Grade { get; set; }


        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Role> Roles { get; set; } = new List<Role>();


        public StudentProfile Profile { get; set; }

        public int? RoomId { get; set; }
        public Room Room { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}