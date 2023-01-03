namespace IdentityCoreMVC.Models
{
    public class ConfirmEmailModel
    {
        public string? Email { get; set; }
        public string? ErrorDescription { get; set; }
        public bool? HasError { get; set; }

    }
}
