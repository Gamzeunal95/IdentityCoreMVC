namespace IdentityCoreMVC.Identities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? UserId { get; set; }
        public MyUser? User { get; set; }
    }
}
