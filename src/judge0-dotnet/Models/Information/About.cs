using System.Text.Json.Serialization;

namespace Judge0.DotNet.Models.Information;

public class About
{
    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("homepage")]
    public string Homepage { get; set; }

    [JsonPropertyName("source_code")]
    public string SourceCode { get; set; }

    [JsonPropertyName("maintainer")]
    public string Maintainer { get; set; }
}