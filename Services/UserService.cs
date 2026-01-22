using Newtonsoft.Json;
using System.Text;
using WebApiFormApp.Models;

namespace WebApiFormApp.Services
{
    public class UserService : IApiService
    {
        private readonly string _baseUrl = "http://localhost:5183/api/user"; // PORTU KENDİNE GÖRE DÜZELT
        private readonly HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        // GET LIST
        public async Task<List<UserDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/getall");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponse<List<UserDto>>>(jsonString);

                if (result != null && result.Success)
                {
                    return result.Data;
                }
            }
            return new List<UserDto>();
        }

        // Register
        public async Task<string> RegisterAsync(UserDto user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/register", content);
            var jsonString = await response.Content.ReadAsStringAsync();

            // API'nin hata mesajını veya başarı mesajını yakalayalım
            try
            {
                var result = JsonConvert.DeserializeObject<ApiResponse<object>>(jsonString);
                return result.Message; // API'den gelen "Kullanıcı eklendi" mesajı
            }
            catch
            {
                return response.IsSuccessStatusCode ? "İşlem Başarılı" : "Hata oluştu";
            }
        }

        // UPDATE
        public async Task<string> UpdateAsync(UserDto user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/update", content); // Clean Arch genelde POST kullanır update için de
            var jsonString = await response.Content.ReadAsStringAsync();

            try
            {
                var result = JsonConvert.DeserializeObject<ApiResponse<object>>(jsonString);
                return result.Message;
            }
            catch
            {
                return response.IsSuccessStatusCode ? "Güncellendi" : "Güncelleme Hatası";
            }
        }

        // DELETE
        // Not: Clean Architecture projelerinde bazen Delete de POST ile yapılır, 
        // bazen entity gönderilir. Standart HTTP Delete varsayıyorum:
        public async Task<string> DeleteAsync(UserDto user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Eğer senin API'de Delete işlemi ID ile değil de Body ile çalışıyorsa:
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_baseUrl}/delete"),
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            var jsonString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ApiResponse<object>>(jsonString);
            return result.Message;
        }

        public Task<bool> CreateAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
