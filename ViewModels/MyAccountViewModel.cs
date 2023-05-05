using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace merketo.ViewModels
{
    public class MyAccountViewModel
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

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail *")]
        public string Email { get; set; } = null!;

        [Display(Name = "Upload profile picture (optional)")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "Role")]
        public string? RoleName { get; set; }


        public static implicit operator AppUser(MyAccountViewModel myAccountViewModel)
        {
            var appUser = new AppUser
            {
                UserName = myAccountViewModel.Email,
                FirstName = myAccountViewModel.FirstName,
                LastName = myAccountViewModel.LastName,
                Email = myAccountViewModel.Email,
                PhoneNumber = myAccountViewModel.PhoneNumber,
            };
            return appUser;
        }

        public static implicit operator ProfileEntity(MyAccountViewModel myAccountViewModel)
        {
            return new ProfileEntity
            {
                StreetName = myAccountViewModel.StreetName,
                PostalCode = myAccountViewModel.PostalCode,
                City = myAccountViewModel.City,
                CompanyName = myAccountViewModel.CompanyName,
            };
        }
    }
}
