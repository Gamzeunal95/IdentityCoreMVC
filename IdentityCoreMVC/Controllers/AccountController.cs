using IdentityCoreMVC.Identities;
using IdentityCoreMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCoreMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyUser> userManager;
        private readonly SignInManager<MyUser> signInManager;

        public AccountController(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var login = new LoginModel();
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = await userManager.FindByEmailAsync(loginModel.Email); // User tablosuna gidip bakacak önce bu kısım 

            if (user == null)
            {
                ModelState.AddModelError("", "Email ya da şifre hatalıdır.");
                return View(loginModel);
            }
            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Email Onaylanmaıştır.");
                return View(loginModel);
            }

            var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, false); // Buradaki false ıdentity ayarlarında verdiğimiz ka. yanlı şifre hakkından sonra kitledindiğne dair kitlensin mi kitlenmesin diye mi biz burada kitlenmesin dedik.
            var result2 = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe);
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "email ya da şifre hatalıdır");
            return View(loginModel);
        }


        public async Task<IActionResult> LoginOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
