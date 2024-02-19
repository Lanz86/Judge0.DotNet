using System.Text.Json.Serialization;

namespace Judge0.DotNet.Models.HealthChecks;

public class Worker
{
    [JsonPropertyName("queue")]
    public string Queue { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("available")]
    public int Available { get; set; }

    [JsonPropertyName("idle")]
    public int Idle { get; set; }

    [JsonPropertyName("working")]
    public int Working { get; set; }

    [JsonPropertyName("paused")]
    public int Paused { get; set; }

    [JsonPropertyName("failed")]
    public int Failed { get; set; }
}