using System.ComponentModel.DataAnnotations;

namespace IdentityCoreMVC.Models
{
    public class RegisterVM // VM-ViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Alanı Zorunludur")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName Alanı Zorunludur")]
        public string UserName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre Alanı Zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre Alanı Zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }


        public string? TcNo { get; set; }

    }
}
