using IdentityCoreMVC.Identities;
using Microsoft.AspNetCore.Identity;

namespace IdentityCoreMVC.Extensions
{
    public static class IdentityAyarlari
    {
        public static string TestTurkce(this string str)
        {

            return str.Replace('ç', 'c').ToString();
        }

        public static IServiceCollection AddCookieAyarlari(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "Account/Login";
                options.LoginPath = "Account/Logout";
                options.AccessDeniedPath = "Account/AccessDenied";
                options.Cookie.Name = "UskudarCookieWeb";
                options.Cookie.HttpOnly = true;        // Tarayıcıdaki diğer scriptler bu cookie'yi okuyamasın.
                options.Cookie.SameSite = SameSiteMode.Strict; // Bizim tarayıcımız dışında kullanılmasın

                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.SlidingExpiration = true; // Expire süresini yeniliyor kullanıma mola verdikten sonra ??
            });
            return services;
        }
        public static IServiceCollection AddIdentityAyarlari(this IServiceCollection services)
        {
            //Burası IOC Container'a Identitty eklemesini soyluyoruz.
            services.AddIdentity<MyUser, IdentityRole<int>>()
                    .AddEntityFrameworkStores<MyIdentityDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                #region Password Kurallari
                //oluşacak şifrenin içerisinde rakam olsun mu ?
                options.Password.RequireDigit = false;
                //Küçük harf zorunluluğu olsun mu ?
                options.Password.RequireLowercase = true;

                // Buyuk harf olsun mu?
                options.Password.RequireUppercase = true;

                options.Password.RequireNonAlphanumeric = false;

                //Password uzunluğu ne kadar olsun ?
                options.Password.RequiredLength = 4;
                #endregion

                #region User ile ilgili options'lar
                //Girilen email uniqe olsun mu?
                options.User.RequireUniqueEmail = true;

                options.User.AllowedUserNameCharacters = @"abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@";
                #endregion

                #region Diğer Ayarlar : SignIn, LockOut
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Lockout.AllowedForNewUsers = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 3;

                #endregion
            });
            return services;
        }
    }
}
