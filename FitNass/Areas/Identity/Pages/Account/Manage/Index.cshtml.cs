using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FitNass.Areas.Identity.Data;
using FitNass.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitNass.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<FitNassUser> _userManager;
        private readonly SignInManager<FitNassUser> _signInManager;

        public IndexModel(
            UserManager<FitNassUser> userManager,
            SignInManager<FitNassUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Required]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
            [MinLength(3, ErrorMessage = "First name cannot be smaller than 3 characters.")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
            [MinLength(3, ErrorMessage = "Last name cannot be smaller than 3 characters.")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date of birth")]
            public DateTime DOB { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Sex")]
            public string Sex { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "Location cannot be longer than 50 characters.")]
            [Display(Name = "Location")]
            public string Location { get; set; }

            /*[Required]
            [UniquePhone]
            [Phone]
            [StringLength(15, ErrorMessage = "Phone Number cannot be longer than 50 characters.")]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }*/
        }

        private async Task LoadAsync(FitNassUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            var firstName = user.FirstName;
            var lastName = user.LastName;
            var dob = user.DOB;
            var sex = user.Sex;
            var location = user.Location;

            Username = userName;

            Input = new InputModel
            {
                FirstName = firstName,
                LastName = lastName,
                DOB = dob,
                Sex = sex,
                Location = location
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            /*var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }*/


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
