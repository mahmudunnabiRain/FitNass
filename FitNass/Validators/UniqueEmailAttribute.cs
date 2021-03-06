using FitNass.Data;
using FitNass.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitNass.Validators
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        public FitNassUser TargetUser { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var user = (FitNassUser)validationContext.ObjectInstance;
            FitNassContext db = (FitNassContext)validationContext.GetService(typeof(FitNassContext));

            var email = ((string)value);

            TargetUser = db.Users.SingleOrDefault(b => b.Email.Equals(email));

            if (TargetUser != null)
            {
                return new ValidationResult($"Email '{email}' is already in use.");
            }

            return ValidationResult.Success;
        }
    }
}
