using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebApiFormApp.Models;
using WebApiFormApp.Statics;

namespace WebApiFormApp.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly Info _info;

        public UserService(IHttpClientFactory httpClientFactory, Info info)
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

        public async Task<UserDto> GetMyProfile()
        {
            if (!string.IsNullOrEmpty(_info.AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _info.AccessToken);
            }
            
            var response = await _httpClient.GetAsync($"{_baseUrl}user/{_info.UserId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<ApiResult<UserDto>>(jsonString);

                if (result != null && result.IsSuccess)
                {
                    return result.Data;
                }
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Hata Detayı: {errorContent}");
                return new UserDto();
            }

            return new UserDto();
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            if (!string.IsNullOrEmpty(_info.AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _info.AccessToken);
            }

            var response = await _httpClient.GetAsync($"{_baseUrl}user/users");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<ApiResult<List<UserDto>>>(jsonString);

                if (result != null && result.IsSuccess)
                {
                    return result.Data;
                }
            }

            return new List<UserDto>();
        }
    }
}