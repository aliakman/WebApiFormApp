using Newtonsoft.Json;

namespace WebApiFormApp.Models
{
    public record LogoutRequest(string RefreshToken, string IpAddress = "0.0.0.0");

    public class LoginSuccessData
    {
        [JsonProperty("accessToken")] // API'deki ismin aynısı olmalı
        public string AccessToken { get; set; } = string.Empty;

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class LoginRootResponse
    {
        [JsonProperty("data")]
        public LoginSuccessData Data { get; set; }

        [JsonProperty("isSuccess")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
