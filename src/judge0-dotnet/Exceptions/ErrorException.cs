using System.Text.Json;
using Judge0.DotNet.Models;

namespace Judge0.DotNet.Exceptions;

public class ErrorException(string body, string reason) : Exception($"An error has occurred. {reason}")
{
    public string Error => JsonSerializer.Deserialize<ErrorResult>(body)?.Error ?? string.Empty;
}