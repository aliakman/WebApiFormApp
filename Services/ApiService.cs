using Microsoft.VisualBasic.ApplicationServices;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using WebApiFormApp.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WebApiFormApp.Services;

public class ApiService(HttpClient httpClient) : IApiService
{
    private string? _token;

    public async Task<bool> LoginAsync(string email, string password)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("auth/login", new { email, password });

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                _token = result?.Token;
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                return true;
            }
            else
            {
                // API hata dönerse (401, 400 vb.) nedenini konsola yazdır
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Hatası: {error}");
                return false;
            }
        }
        catch (Exception ex)
        {
            // Bağlantı kopukluğu veya yanlış URL durumunda burası çalışır
            MessageBox.Show($"Bağlantı Hatası: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> RegisterAsync(UserCreateRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("user/register", request);
        return response.IsSuccessStatusCode;
    }

    //public async Task<List<UserDto>> GetUsersAsync()
    //{

    //    var resp = await httpClient.GetAsync("user/users");
    //    var body = await resp.Content.ReadAsStringAsync();
    //    if (!resp.IsSuccessStatusCode)
    //    {
    //        Console.WriteLine($"GetUsers failed: {(int)resp.StatusCode} {resp.ReasonPhrase} Body: {body}");
    //        return new List<UserDto>();
    //    }

    //    var users = await resp.Content.ReadFromJsonAsync<List<UserDto>>();
    //    return users ?? new List<UserDto>();
    //}

    public async Task<List<UserDto>> GetUsersAsync()
    {
        var resp = await httpClient.GetAsync("user/users");
        if (!resp.IsSuccessStatusCode) return new List<UserDto>();

        // Doğrudan List<UserDto> değil, ApiResult<List<UserDto>> olarak oku
        var result = await resp.Content.ReadFromJsonAsync<ApiResult<List<UserDto>>>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return result?.Data ?? new List<UserDto>();
    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var _user = await httpClient.GetFromJsonAsync<UserDto>($"user/{id}");

        UserDto user = new UserDto();
        user.Id = _user?.Id ?? new();
        user.FirstName = _user?.FirstName ?? new();
        user.LastName = _user?.LastName ?? new();
        user.UserName = _user?.UserName ?? new();
        user.Email = _user?.Email ?? new();
        user.Roles = _user?.Roles ?? [];
        return user;
    }

    public async Task<UserDto> GetUserByUsernameAsync(string username)
            => await httpClient.GetFromJsonAsync<UserDto>($"user/userbyusername/{username}") ?? new UserDto();

    public async Task<List<RoleDto>> GetUserRolesByIdAsync(Guid id)
        => await httpClient.GetFromJsonAsync<List<RoleDto>>($"user/userbyusername/{id}") ?? [];

    public async Task<bool> UpdateUserAsync(string userName, UserUpdateRequest request)
    {
        // Clean Architecture projesindeki rotaya uygun: PUT api/users/{userName}
        var response = await httpClient.PutAsJsonAsync($"user/{userName}", request);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteUserAsync(string userName)
    {
        var response = await httpClient.DeleteAsync($"user/{userName}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> AddRoleToUserAsync(string userName, string roleName)
    {
        var response = await httpClient.PostAsJsonAsync($"user/{userName}/roles", new { roleName });
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveRoleFromUserAsync(string userName, string roleName)
    {
        var response = await httpClient.DeleteAsync($"user/{userName}/roles/{roleName}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<RoleDto>> GetAllRolesAsync()
    {
        // API: GET api/roles
        return await httpClient.GetFromJsonAsync<List<RoleDto>>("role/getallroles") ?? [];
    }

    public async Task<bool> CreateRole(string roleName)
    {
        var response = await httpClient.PostAsJsonAsync($"role/createrole/{roleName}", new {roleName});
        return response.IsSuccessStatusCode;
    }

    public void Logout()
    {
        _token = null;
        httpClient.DefaultRequestHeaders.Authorization = null;
    }
}