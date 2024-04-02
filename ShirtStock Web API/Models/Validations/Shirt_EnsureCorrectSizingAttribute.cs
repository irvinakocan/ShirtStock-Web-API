using System;
using System.ComponentModel.DataAnnotations;

namespace ShirtStock_Web_API.Models.Validations
{
	public class Shirt_EnsureCorrectSizingAttribute: ValidationAttribute
	{
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;

            if (shirt != null && !string.IsNullOrEmpty(shirt.Gender))
            {
                if(shirt.Gender.Equals("man", StringComparison.OrdinalIgnoreCase) && (shirt.Size < 8 || shirt.Size > 20))
                {
                    return new ValidationResult("For man's shirts the size has to be between 8 and 20.");
                }
                else if (shirt.Gender.Equals("woman", StringComparison.OrdinalIgnoreCase) && (shirt.Size < 6 || shirt.Size > 18))
                {
                    return new ValidationResult("For woman's shirts the size has to be between 6 and 18.");
                }
            }

            return ValidationResult.Success;
        }
    }
}

