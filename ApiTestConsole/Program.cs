using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiTestConsole
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            LoginModel loginModel = new LoginModel { Email = "ali@gmail.com", Password = "123" };
            var token = await GetToken(loginModel);
            Console.WriteLine(token.AccessToken);
            await GetMernis(token);
            Console.ReadLine();

        }

        public static async Task<Token> GetToken(LoginModel model)
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

        public static async Task GetMernis(Token token)
        {
            var url = @"https://localhost:7280/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken.Replace("Bearer", ""));

            HttpResponseMessage responseMessage = await client.GetAsync("api/Mernis/");

            var jsonResult = responseMessage.Content.ReadAsStringAsync().Result;
            var mernis = JsonConvert.DeserializeObject<List<Citizen>>(jsonResult);


            foreach (var item in mernis)
            {
                await Console.Out.WriteLineAsync(item.nationalIdentifier + "=>" + item.first + " " + item.last);
            }

        }
    }
}