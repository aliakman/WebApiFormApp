namespace WebApiFormApp.Models;

//public class UserDto
//{

//    public Guid Id { get; set; } = default;
//    public string FirstName { get; set; } = string.Empty;
//    public string LastName { get; set; } = string.Empty;
//    public string UserName { get; set; } = string.Empty;
//    public string Email { get; set; } = string.Empty;
//    public List<string> Roles { get; set; } = new();
//}

public class UserDto
{
    public Guid Id { get; set; }
    public ValueObjectDto FirstName { get; set; } = new();
    public ValueObjectDto LastName { get; set; } = new();
    public ValueObjectDto UserName { get; set; } = new();
    public ValueObjectDto Email { get; set; } = new();

    public List<RoleDto> Roles { get; set; } = new();
}


//public UserDto(Guid _id, string _fN, string _lN, string _un, string _email, List<string> _roles) 
//{
//    Id = _id;
//    FirstName = _fN;
//    LastName = _lN;
//    UserName = _un;
//    Email = _email;
//    Roles = _roles;
//}

public record UserCreateRequest(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password);

public record UserUpdateRequest(
    Guid UserID,
    string FirstName,
    string LastName);

public record LoginResponse(
    string Token, 
    DateTime Expiration);