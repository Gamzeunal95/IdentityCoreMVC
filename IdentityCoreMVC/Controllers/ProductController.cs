using IdentityCoreMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCoreMVC.Controllers
{

    //[Authorize(Roles = "Admin")] // Bu şekilde yazdığımızda sadece adminlerin prodcut sayfasına girmesine izin vermiş oluyoruz. Rolu sadece Admin olanlara açılıyor. 
    // Yukarıdaki gibinin yerine açtığımız izinler clasıyla da aşağıdaki gibi de yapabiliriz.
    [Authorize(Roles = $"{Izinler.ProductRead}")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
