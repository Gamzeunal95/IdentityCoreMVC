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

        public IEnumerable<string> Roles { get; set; }


    }
}
