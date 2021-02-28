using FitNass.Areas.Identity.Data;
using FitNass.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitNass.Validators
{
    public class UniquePhoneAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var user = (FitNassUser)validationContext.ObjectInstance;
            FitNassContext db = (FitNassContext)validationContext.GetService(typeof(FitNassContext));

            var phoneNumber = ((string)value);
            var targetUser = db.Users.SingleOrDefault(b => b.PhoneNumber.Equals(phoneNumber));


            if (targetUser != null)
            {
                return new ValidationResult($"Phone Number '{phoneNumber}' is already in use.");
            }

            return ValidationResult.Success;
        }
    }
}
