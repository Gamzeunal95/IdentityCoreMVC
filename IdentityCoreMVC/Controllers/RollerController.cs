using IdentityCoreMVC.Identities;
using IdentityCoreMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCoreMVC.Controllers
{
    public class RollerController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly UserManager<MyUser> userManager;

        public RollerController(RoleManager<IdentityRole<int>> roleManager, UserManager<MyUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }


        public IActionResult Index()
        {

            var result = roleManager.Roles.ToList();

            return View(result);
        }
        public IActionResult Create()
        {
            IdentityRole<int> role = new();
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole<int> role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }

            var result = await roleManager.CreateAsync(role);


            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Roller");
            }

            return View(role);
        }


        [HttpGet]
        public IActionResult Edit(int id) // Update
        {
            var role = roleManager.FindByIdAsync(id.ToString()).Result;

            return View(role);
        }

        [HttpPost]
        public IActionResult Edit(IdentityRole<int> role) // Update
        {
            var result = roleManager.UpdateAsync(role).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Roller");
            }
            return View(role);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var role = roleManager.FindByIdAsync(id.ToString()).Result;
            var users = userManager.Users.ToList();

            foreach (var user in users)
            {
                var roller = userManager.GetRolesAsync(user).Result;
                if (roller != null)
                {
                    foreach (var item in roller)
                    {
                        if (item == role.Name)
                        {
                            return RedirectToAction("Index", "Roller");
                        }
                    }

                    var sonuc = roleManager.DeleteAsync(role).Result;
                    if (sonuc.Succeeded)
                    {
                        return RedirectToAction("Index", "Roller");
                    }
                }
            }

            return View(role);
        }

        [HttpPost]
        public IActionResult Delete(IdentityRole<int> role)
        {
            var result = roleManager.UpdateAsync(role).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Roller");
            }
            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> Kullanicilar()
        {
            List<UsersRoles> usersRoles = new List<UsersRoles>();
            var users = userManager.Users.ToList();
            foreach (var user in users)
            {
                var kullanici = new UsersRoles()
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
                kullanici.Roles = userManager.GetRolesAsync(user).Result;
                usersRoles.Add(kullanici);
            }

            return View(usersRoles);
        }
    }
}
