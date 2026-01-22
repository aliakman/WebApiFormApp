using Newtonsoft.Json;

namespace WebApiFormApp.Models;

public class RoleDto
{
    [JsonProperty("id")]
    public ValueObjectDto<Guid> Id { get; set; }

    [JsonProperty("name")]
    public ValueObjectDto<string> Name { get; set; }
}

public class RoleResponseWrapper
{
    [JsonProperty("role")]
    public RoleDto Role { get; set; }
}