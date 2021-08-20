using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [Table("RenamedRoom")]
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column("BuildingFloor", TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public int Floor { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}