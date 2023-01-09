using Newtonsoft.Json;

namespace IdentityCoreMVC.Models
{
    public class Token
    { // token ile alakalı propertylerini yazıyoruz Postmande token aldığımızda verdiği özelliklere göre burada aynı yazım şekli ile belirttik.
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }


        [JsonProperty("expiration")]
        public string Expiration { get; set; }


        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

    }
}