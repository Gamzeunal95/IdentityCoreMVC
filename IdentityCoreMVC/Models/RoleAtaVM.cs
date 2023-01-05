namespace IdentityCoreMVC.Models
{
    public class RoleAtaVM
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool HasAssigned { get; set; }
    }
}
