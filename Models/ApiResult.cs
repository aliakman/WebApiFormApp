using Newtonsoft.Json;

namespace WebApiFormApp.Models
{
    public class ApiResult<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public object Errors { get; set; }
    }
}