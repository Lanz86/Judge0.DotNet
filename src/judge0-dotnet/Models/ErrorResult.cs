using System.Text.Json.Serialization;

namespace Judge0.DotNet.Models
{
    public class ErrorResult
    {
        [JsonPropertyName("error")]
        public string Error { get; set; } = string.Empty;
    }
}
