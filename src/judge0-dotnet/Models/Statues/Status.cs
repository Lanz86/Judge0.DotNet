using System.Text.Json.Serialization;

namespace Judge0.DotNet.Models.Statues;

public class Status
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("description")] 
    public string Description { get; set; } = string.Empty;
}