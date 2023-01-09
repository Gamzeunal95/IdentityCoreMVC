using IdentityCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace IdentityCoreMVC.Controllers
{

    public class MernisController : Controller
    {
        public async Task<IActionResult> Index()
        {
            LoginApiModel apiModel = new LoginApiModel { Email = "ali@gmail.com", Password = "123" };

            var token = await GetToken(apiModel);

            var result = await GetMernis(token);

            return View(result);
        }


        [NonAction] // Dışarıya açmasın diye nonaction yazıldı. 
        public async Task<Token> GetToken(LoginApiModel model)
        {
            var url = @"https://localhost:7280/api/Login/Login";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var serilizeObject = System.Text.Json.JsonSerializer.Serialize(model);
            var stringContext = new StringContent(serilizeObject, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(url, stringContext);


            var jsonResult = responseMessage.Content.ReadAsStringAsync().Result;
            var token = JsonConvert.DeserializeObject<Token>(jsonResult);

            return token;
        }

        [NonAction] // Dışarıya açmasın diye nonaction yazıldı. 
        public async Task<List<Citizen>> GetMernis(Token token)
        {
            var url = @"https://localhost:7280/";  // Buradaki port swaggerda görünen portla aynı
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken.Replace("Bearer", ""));

            HttpResponseMessage responseMessage = await client.GetAsync("api/Mernis/");

            var jsonResult = responseMessage.Content.ReadAsStringAsync().Result;

            var mernis = JsonConvert.DeserializeObject<List<Citizen>>(jsonResult);

            return mernis;

        }
    }
}
