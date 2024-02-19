using System.Net;
using System.Text.Json;
using Judge0.DotNet.Exceptions;

namespace Judge0.DotNet.Models 
{
    public static class ResponseResultExtensions {
        public static async Task<T?> BuildResponseResult<T>(this HttpResponseMessage response,
            CancellationToken cancellationToken = default) where T : class, new()
        {
            string jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return response.StatusCode switch
            {
                HttpStatusCode.NotFound => throw new NotFoundException(),
                (HttpStatusCode)422 => throw new ValidationException(jsonResult),
                HttpStatusCode.ServiceUnavailable => throw new ErrorException(jsonResult, "Service Unavailable"),
                HttpStatusCode.BadRequest => throw new ErrorException(jsonResult, "Bad Request"),
                HttpStatusCode.Unauthorized => throw new UnauthorizedException(),
                HttpStatusCode.Forbidden => throw new ForbiddenException(),
                HttpStatusCode.OK or HttpStatusCode.Created or HttpStatusCode.Accepted =>
                    !string.IsNullOrWhiteSpace(jsonResult) ? JsonSerializer.Deserialize<T>(jsonResult) : new T(),
                _ => throw new Exception(jsonResult)
            };
        }
    }
}