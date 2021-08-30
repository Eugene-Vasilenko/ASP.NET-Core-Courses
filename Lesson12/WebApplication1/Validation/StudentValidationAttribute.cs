using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.DTO;

namespace WebApplication1.Validation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StudentValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var student = (dtoStudent)value;

            if (student == null)
            {
                return false;
            }

            return student.Name.StartsWith("Test");
        }
    }
}
