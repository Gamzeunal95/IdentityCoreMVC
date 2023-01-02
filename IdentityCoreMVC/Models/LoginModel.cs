using System.ComponentModel.DataAnnotations;

namespace IdentityCoreMVC.Models
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email alani Zorunludur")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre Zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; } = false;
        public string? Token { get; set; }
    }
}
