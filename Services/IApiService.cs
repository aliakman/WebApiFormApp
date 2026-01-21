using WebApiFormApp.Models;

namespace WebApiFormApp.Services;

public interface IApiService
{
    Task<bool> LoginAsync(string email, string password);
    Task<bool> RegisterAsync(UserCreateRequest request);
    void Logout();

    Task<List<UserDto>> GetUsersAsync();
    Task<UserDto> GetUserByIdAsync(Guid id);
    Task<UserDto> GetUserByUsernameAsync(string username);
    Task<List<RoleDto>> GetUserRolesByIdAsync(Guid id);

    // HATA BURADAYDI: Parametreleri UserName ve Request olarak güncelledik
    Task<bool> UpdateUserAsync(string userName, UserUpdateRequest request);

    Task<bool> DeleteUserAsync(string userName);
    Task<bool> AddRoleToUserAsync(string userName, string roleName);
    Task<bool> RemoveRoleFromUserAsync(string userName, string roleName);

    Task<List<RoleDto>> GetAllRolesAsync();
    Task<bool> CreateRole(string roleName);

}