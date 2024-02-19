using System.Text.Json.Serialization;

namespace Judge0.DotNet.Models.Submissions;

public class SubmissionsResponse
{
    [JsonPropertyName("submissions")]
    public List<SubmissionResponse> Submissions { get; set; } = new();
}