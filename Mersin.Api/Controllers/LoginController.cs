using Mersin.Api.entities;
using Mersin.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mersin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MernisContext context;
        private readonly IConfiguration configuration;

        public LoginController(MernisContext context, IConfiguration configuration) // field olusturuldu
        {
            this.context = context;
            this.configuration = configuration;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            User user = await context.Users
                               .Include(u => u.UserRoles)
                               .ThenInclude(p => p.Role)
                               .FirstOrDefaultAsync(p => p.Email == loginModel.Email && p.Password == loginModel.Password);
            if (user != null)
            {
                //Token uretme aşaması
                TokenHandler tokenHandler = new(configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                // Refresh token'i User tablosuna ekleme
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndTime = token.Expiration.AddMinutes(3);
                await context.SaveChangesAsync();
                return Ok(token);
            }
            return NotFound();
        }
    }
}
