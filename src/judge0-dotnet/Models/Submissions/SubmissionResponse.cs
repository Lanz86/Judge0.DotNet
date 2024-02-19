using System.Text.Json.Serialization;
using Judge0.DotNet.Extensions;
using Judge0.DotNet.Models.Statues;

namespace Judge0.DotNet.Models.Submissions;

public class SubmissionResponse
{
    /// <summary>
    ///Standard output of the program after execution.
    /// </summary>
    [JsonPropertyName("stdout")]
    public string? Stdout { get; set; }

    /// <summary>
    ///Standard error of the program after execution. 
    /// </summary>
    [JsonPropertyName("stderr")]
    public string? Stderr { get; set; }

    /// <summary>
    /// Standard error of the program after execution.
    /// </summary>
    [JsonPropertyName("compile_output")]
    public string? CompileOutput { get; set; }

    /// <summary>
    /// Status message from Judge0 or isolate.")]
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The program’s exit code.
    /// </summary>
    [JsonPropertyName("exit_code")]
    public string? ExitCode { get; set; }

    /// <summary>
    /// Signal code that the program received before exiting.")]
    /// </summary>
    [JsonPropertyName("exit_signal")]
    public string? ExitSignal { get; set; }

    /// <summary>
    ///Submission status.
    /// </summary>
    [JsonPropertyName("status")]
    public StatusResponse? Status { get; set; } 

    /// <summary>
    /// Date and time when submission was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date and time when submission was processed. Null if still in queue or processing.
    /// </summary>
    [JsonPropertyName("finished_at")]
    public DateTime? FinishedAt { get; set; } = null;

    /// <summary>
    /// Unique submission token for specific submission.
    /// </summary>
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Program’s run time in seconds.
    /// </summary>
    [JsonPropertyName("time")]
    public string? Time { get; set; }

    /// <summary>
    /// Program’s wall time in seconds.
    /// </summary>
    [JsonPropertyName("wall_time")]
    public string? WallTime { get; set; }

    /// <summary>
    ///Memory used by the program after execution in kilobytes.
    /// </summary>
    [JsonPropertyName("memory")]
    public float? Memory { get; set; }
    
    [JsonPropertyName("language_id")] 
    public int? LanguageId { get; set; } = null;

    [JsonPropertyName("status_id")] 
    public int? StatusId { get; set; } = null;

    public Task FromBase64()
    {
        Stdout = Stdout.FromBase64();
        Stderr = Stderr.FromBase64();
        CompileOutput = CompileOutput.FromBase64();
        Message = Message.FromBase64();

        return Task.CompletedTask;
    }
}
