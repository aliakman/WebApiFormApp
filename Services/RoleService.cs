using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using WebApiFormApp.Models;
using WebApiFormApp.Statics;

namespace WebApiFormApp.Services
{
    public class RoleService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly Info _info;

        public RoleService(IHttpClientFactory httpClientFactory, Info info)
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

        public async Task<List<RoleDto>> GetAllRolesAsync()
        {
            if (!string.IsNullOrEmpty(_info.AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _info.AccessToken);
            }

            var response = await _httpClient.GetAsync($"{_baseUrl}role/roles");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<ApiResult<List<RoleResponseWrapper>>>(jsonString);

                if (result != null && result.IsSuccess)
                {
                    return result.Data
                                 .Select(x => x.Role)
                                 .ToList();
                }
            }

            return new List<RoleDto>();
        }
    }
}