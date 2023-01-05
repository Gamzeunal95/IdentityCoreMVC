using IdentityCoreMVC.Identities;
using IdentityCoreMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityCoreMVC.Controllers
{
    [Authorize]
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

        [HttpGet]
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


        [Authorize(Roles = "Admin")]
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


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> RolAta(int id)
        {
            List<RoleAtaVM> roleAtaVMs = new List<RoleAtaVM>();


            var user = userManager.FindByIdAsync(id.ToString()).Result;


            var roller = roleManager.Roles.ToList();
            var userRolleri = userManager.GetRolesAsync(user).Result;
            #region Bu şekilde de yazabiliriz.
            //roller.ForEach(role => roleAtaVMs.Add(new RoleAtaVM
            //{
            //    UserId = user.Id,
            //    RoleId = role.Id,
            //    RoleName = role.Name,
            //    HasAssigned = userRolleri.Contains(role.Name)
            //})); 
            #endregion

            //Bu şekildede 
            foreach (var rol in roller)
            {
                RoleAtaVM roleAtaVM = new RoleAtaVM();
                roleAtaVM.UserId = user.Id;
                roleAtaVM.RoleId = rol.Id;
                roleAtaVM.RoleName = rol.Name;
                roleAtaVM.HasAssigned = userRolleri.Contains(rol.Name);
                roleAtaVMs.Add(roleAtaVM);
            }

            return View(roleAtaVMs);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RolAta(List<RoleAtaVM> modelList, int id) // aslında int değil guid olması gerekir güvenlik açığına sebebiyet vermemek için
        {
            MyUser user = await userManager.FindByIdAsync(id.ToString());

            foreach (var role in modelList)
            {
                if (role.HasAssigned)
                {
                    await userManager.AddToRoleAsync(user, role.RoleName);
                }
                else
                {
                    await userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }

            return RedirectToAction("Kullanicilar", "Roller");
        }
    }
}
