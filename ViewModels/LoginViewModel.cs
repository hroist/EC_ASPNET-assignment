using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You must enter an email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail *")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password")]
        [Display(Name = "Password *")]
        public string Password { get; set; } = null!;

        [Display(Name = "Keep me logged in")]
        public bool RememberMe { get; set; } = false;
    }
}
