using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FitNass.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the FitNassUser class
    public class FitNassUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(10)")]
        public string Sex { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Location { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(500)")]
        public string Biodata { get; set; }
    }
}
