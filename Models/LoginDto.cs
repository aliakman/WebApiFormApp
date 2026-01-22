using Newtonsoft.Json;

namespace WebApiFormApp.Models
{
    public record LogoutRequest(string RefreshToken, string IpAddress = "0.0.0.0");

    public class LoginSuccessData
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("userId")] // Eğer API bunu gönderiyorsa
        public Guid UserId { get; set; }
    }
}
