using Newtonsoft.Json;

namespace WebApiFormApp.Models
{
    public class UserDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("roles")]
        public List<RoleDto> Roles { get; set; } = new();

        public string RoleNamesDisplay => (Roles != null && Roles.Any())
            ? string.Join(", ", Roles.Select(r => r.Name.Value))
            : "Rol Tanımlı Değil";

        public string FullName => $"{FirstName} {LastName}";
    }
}