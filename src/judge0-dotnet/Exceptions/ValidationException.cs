using System.Text.Json;

namespace Judge0.DotNet.Exceptions;

public class ValidationException(string body) : Exception("One or more validation failures have occurred.")
{
    public Dictionary<string, string[]>? Errors { get; } = JsonSerializer.Deserialize<Dictionary<string, string[]>>(body);
}