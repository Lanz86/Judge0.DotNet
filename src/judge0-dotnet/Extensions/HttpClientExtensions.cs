using System.Text;
using System.Text.Json;

namespace Judge0.DotNet.Extensions;

public static class HttpClientExtensions
{
    public static Task<HttpResponseMessage> PostAsJsonAsync<TValue>(this HttpClient client, string? requestUri, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default(CancellationToken))
    {
        if (client == null) throw new ArgumentNullException(nameof(client));
        StringContent content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
        return client.PostAsync(requestUri, content, cancellationToken);
    }
}
