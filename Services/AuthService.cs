using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using WebApiFormApp.Models;
using WebApiFormApp.Statics;

namespace WebApiFormApp.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly Info _info;

        public AuthService(IHttpClientFactory httpClientFactory, Info info)
        {
            // Program.cs'de tanýmladýðýmýz "api" ayarlarýný (BaseAddress vb.) yükler
            _httpClient = httpClientFactory.CreateClient("api");
            _baseUrl = _httpClient.BaseAddress?.ToString() ?? "http://localhost:5183/api/";
            _info = info;

            // Her istekte güncel token'ý ekle
            if (!string.IsNullOrEmpty(_info.AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", _info.AccessToken);
            }
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}auth/login", new { email, password });
            var jsonString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ApiResult<LoginSuccessData>>(jsonString);

            if (result != null && result.IsSuccess && result.Data != null)
            {
                _info.SetEmail(email);
                _info.SetPassword(password);
                _info.SetUserId(result.Data.UserId);
                _info.SetAccessToken(result.Data.AccessToken);
                _info.SetRefreshToken(result.Data.RefreshToken);

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _info.AccessToken);

                return true;
            }
            return false;
        }

        public async Task<bool> Logout()
        {
            try
            {
                string currentRefreshToken = _info.RefreshToken ?? "";
                LogoutRequest _request = new(currentRefreshToken);
                HttpContent _content = JsonContent.Create(_request);

                CancellationToken _cancellationToken = new();

                var response = await _httpClient.PostAsync($"{_baseUrl}auth/logout", _content, _cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    _info.SetRefreshToken("");
                    _httpClient.DefaultRequestHeaders.Authorization = null;
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Hatasý: {error}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Baðlantý Hatasý: {ex.Message}");
                return false;
            }
        }
    }
}