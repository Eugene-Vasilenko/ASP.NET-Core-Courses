using ConsoleApp1.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Validation;

namespace WebApplication1.DTO
{
    [StudentValidation(ErrorMessage = "Name should start with Test")]
    public class dtoStudent : IValidatableObject
    {
        public int Id { get; set; }

        [Required()]
        public string Name { get; set; }

        [IsStringInRangeValidation(new[] { "Doctor", "Master", "Bachelor" })]
        public string Grade { get; set; }
        public int? RoomId { get; set; }

        public void Map(Student ent)
        {
            ent.Id = Id;
            ent.Name = Name;
            ent.Grade = Grade;
            ent.RoomId = RoomId;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (RoomId != 1)
            {
                result.Add(new ValidationResult("Value " + RoomId + " is not valid", new[] { "RoomId", "Name" }));
            }

            return result;
        }
    }
}
