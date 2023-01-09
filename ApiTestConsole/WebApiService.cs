namespace ApiTestConsole
{
    public class WebApiService
    {
        static string url = @"http://localhost:7280/";  // Mersin.Api ye terminalde konumlanım dotnet run yaz ıp adresini öğrenebilirsiniz. YA DA launchSettings.json dosyasından
        static string serviceUrl = "";
        static HttpClient client = new HttpClient();

        public static async Task<string> GetAll(string method)
        {
            serviceUrl = $"{url}api/mernis/{method}";
            using (HttpResponseMessage response = await client.GetAsync(serviceUrl))
                return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> GetToken(string email, string password)
        {
            serviceUrl = $"{url}api/Login/Login";
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>()
            {
             new KeyValuePair<string, string>("grant_type", "password"),
             new KeyValuePair<string, string>("email", email),
             new KeyValuePair<string, string>("password", password)

            };

            HttpContent content = new FormUrlEncodedContent(pairs);
            using (HttpResponseMessage responseMessage = await client.PostAsync(serviceUrl, content))
                return await responseMessage.Content.ReadAsStringAsync();
        }
    }
}
