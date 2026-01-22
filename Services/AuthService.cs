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
            _httpClient = httpClientFactory.CreateClient("api");
            _baseUrl = _httpClient.BaseAddress?.ToString() ?? "http://localhost:5183/api/";
            _info = info;

            if (!string.IsNullOrEmpty(_info.AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", _info.AccessToken);
            }
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                var loginModel = new { email, password };
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}auth/login", loginModel);

                var jsonString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<LoginRootResponse>(jsonString);

                    if (result != null && result.Success && result.Data != null)
                    {
                        _info.SetAccessToken(result.Data.AccessToken);
                        _info.SetRefreshToken(result.Data.RefreshToken);

                        _httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", _info.AccessToken);

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
                return false;
            }
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