using Microsoft.AspNetCore.Identity;

namespace IdentityCoreMVC.Identities
{
    public class MyUser : IdentityUser<int>
    {
        // Zorunlu olan olacaksa burayıda yazmak gerekir ama biz nullable yaptık.
        //public MyUser()
        //{
        //    Categoriler = new HashSet<Category>();
        //}
        public string? TcNo { get; set; }

        // Navigation propertiler db'ye yansımaz. Burası DB'ye yansımaz.Sadece Dbcontext sınıfını sorgularken navgation property olarak tanımlıyoruz.
        public ICollection<Category>? Categoriler { get; set; }
    }
}
