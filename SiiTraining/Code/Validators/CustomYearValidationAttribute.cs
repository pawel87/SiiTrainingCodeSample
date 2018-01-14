using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTraining.Code.Validators
{
    public class CustomYearValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //some custom logic
            var currentYear = (int)value;

            if(currentYear < 1900 || currentYear > 2100)
            {
                return new ValidationResult("Some error message...");
            }

            return ValidationResult.Success;
        }

    }
}
