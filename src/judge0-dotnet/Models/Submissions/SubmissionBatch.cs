using System.Text.Json.Serialization;

namespace Judge0.DotNet.Models.Submissions;

public class SubmissionBatch
{
    [JsonPropertyName("submissions")]
    public IEnumerable<Submission> Submissions { get; set; } = Enumerable.Empty<Submission>();
}