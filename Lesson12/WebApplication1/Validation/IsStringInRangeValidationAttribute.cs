using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication1.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsStringInRangeValidationAttribute : ValidationAttribute
    {
        private readonly string[] _allovedValues;

        public IsStringInRangeValidationAttribute(string[] allovedValues)
            : base(GetErrorMessage(allovedValues))
        {
            _allovedValues = allovedValues;
        }

        public override bool IsValid(object? value)
        {
            return value != null && _allovedValues.Contains(value.ToString());
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }

        private static Func<string> GetErrorMessage(string[] allovedValues)
        {
            return () => "The {0} field should be one of: " + string.Join(", ", allovedValues);
        }
    }
}
