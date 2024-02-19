using System.Text.Json.Serialization;

namespace Judge0.DotNet.Models.Languages;

public class Language
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")] 
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("is_archived")] 
    public bool IsArchived { get; set; } = false;
}