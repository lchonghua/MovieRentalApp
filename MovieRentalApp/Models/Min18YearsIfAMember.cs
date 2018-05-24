using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalApp.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0||customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            else
            {
                if (customer.Birthday == null)
                    return new ValidationResult("Birthday is required.");
                var age = DateTime.Today.Year - customer.Birthday.Value.Year;
                return (age >= 18) 
                    ? ValidationResult.Success 
                    : new ValidationResult("Customer should be at least 18 years old to go on a membership");
            }
        }
    }
}