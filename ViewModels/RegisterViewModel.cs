using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter your first name")]
        [Display(Name = "First name *")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Enter a valid first name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Enter your last name")]
        [Display(Name = "Last name *")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Enter a valid last name")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Enter your street name")]
        [Display(Name = "Street name *")]
        public string StreetName { get; set; } = null!;

        [Required(ErrorMessage = "Enter your postal code")]
        [Display(Name = "Postal code *")]
        public string PostalCode { get; set; } = null!;

        [Required(ErrorMessage = "Enter city")]
        [Display(Name = "City *")]
        public string City { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile (optional)")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Company (optional)")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail *")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid e-mail address")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter a password")]
        [Display(Name = "Password *")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Enter a secure password (minimum 8 characters, using both numbers, upper and lower cases)")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The passwords does not match")]
        [Required(ErrorMessage = "Confirm your chosen password")]
        [Display(Name = "Confirm password *")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Upload profile picture (optional)")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "I have read and accept the terms and conditions")]
        [Required(ErrorMessage = "You must agree to the terms and conditions")]
        public bool Terms { get; set; } = false;


        public static implicit operator AppUser(RegisterViewModel registerViewModel)
        {
            var appUser = new AppUser { 
                UserName = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                PhoneNumber = registerViewModel.PhoneNumber,
            };
            return appUser;
        }

        public static implicit operator ProfileEntity(RegisterViewModel registerViewModel)
        {
            return new ProfileEntity 
            { 
                StreetName = registerViewModel.StreetName,
                PostalCode = registerViewModel.PostalCode,
                City = registerViewModel.City,
                CompanyName = registerViewModel.CompanyName,
            };
        }
    }
}
