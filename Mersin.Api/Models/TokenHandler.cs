using Mersin.Api.entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Mersin.Api.Models
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Token Uretilne Metod
        /// </summary>
        /// <param name="user">User cinsinden olmali</param>
        /// <returns></returns>
        public Token CreateAccessToken(User user)
        {
            List<Claim> claims = new List<Claim>();

            foreach (var item in user.UserRoles)
            {
                //item.Role.Name
                claims.Add(new Claim(ClaimTypes.Role, item.Role.Name));

            }

            Token tokenInstance = new Token();

            //Security  Key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            //Oluşturulacak token ayarlarını veriyoruz.
            tokenInstance.Expiration = DateTime.Now.AddMinutes(5);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"], // Olusturulacak token değerini kimlerin-hangi orjinlerin-hangi sitelerin kullanacağını belirtir.
                audience: Configuration["Token:Audience"],// Olustutulacak token değerinin kimin tarafından olusturulduğun verir.
                expires: tokenInstance.Expiration,//Token süresini 5 dk olarak belirliyorum
                claims: claims, // Yukarida olusturulan claim'lerin listesini veriyoruz
                notBefore: DateTime.Now,//Token üretildikten ne kadar süre sonra devreye girsin ayarlıyouz.
                signingCredentials: signingCredentials
                );

            //Token oluşturucu sınıfında bir örnek alıyoruz.
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //Token üretiyoruz.
            tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken);

            tokenInstance.AccessToken = "Bearer " + tokenInstance.AccessToken;
            //Refresh Token üretiyoruz.
            tokenInstance.RefreshToken = CreateRefreshToken();
            return tokenInstance;
        }

        //Refresh Token üretecek metot.
        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }


        //public Token CreateAccessTokenWithClaims(User user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(Configuration["Token:Screet"]);

        //    List<Claim> claims = new List<Claim>();

        //    foreach (var item in user.UserRoles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, item.Role.Name));
        //    }
        //    claims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));


        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    user.Token = tokenHandler.WriteToken(token);


        //}
    }
}
