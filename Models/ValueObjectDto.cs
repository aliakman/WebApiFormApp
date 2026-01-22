using Newtonsoft.Json;

namespace WebApiFormApp.Models
{
    public class ValueObjectDto<T>
    {
        [JsonProperty("value")]
        public T Value { get; set; }

        public override string ToString() => Value?.ToString() ?? string.Empty;
    }
}
