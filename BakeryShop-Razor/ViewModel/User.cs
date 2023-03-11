using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BakeryShop_Razor.ViewModel
{
    public class User
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Passwored")]
        [Compare("Password", ErrorMessage = "Passwored and Confirmation Passwored are not matched")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
