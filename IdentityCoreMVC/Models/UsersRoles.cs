namespace IdentityCoreMVC.Models
{
    public class UsersRoles
    {

        public UsersRoles()
        {
            Roles = new List<string>();

        }
        public int Id { get; set; }
        public string UserName { get; set; }

        public ICollection<string> Roles { get; set; }


    }
}
