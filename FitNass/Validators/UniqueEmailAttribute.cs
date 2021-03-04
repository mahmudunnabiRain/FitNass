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


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var user = (FitNassUser)validationContext.ObjectInstance;
            FitNassContext db = (FitNassContext)validationContext.GetService(typeof(FitNassContext));

            var email = ((string)value);
            var targetUser = db.Users.SingleOrDefaultAsync(b => b.Email.Equals(email));

            if (targetUser != null)
            {
                return new ValidationResult($"Email '{email}' is already in use.");
            }

            return ValidationResult.Success;
        }
    }
}
