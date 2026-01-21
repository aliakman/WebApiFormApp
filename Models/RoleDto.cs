namespace WebApiFormApp.Models;

public class RoleDto
{
    public Guid Id { get; set; }
    public RoleNameDto Name { get; set; } = new();
}

public class RoleNameDto
{
    // API'den gelen "name" nesnesinin içindeki gerçek metin alanı
    // Eğer API'de bu alanın adı farklıysa (örn: "Value") ona göre değiştirin.
    public string Value { get; set; } = string.Empty;

    public override string ToString() => Value;
}